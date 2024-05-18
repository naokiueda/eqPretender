using System;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace eqPretender
{
    public class EQPretender
    {
        private Communicator mount;
        private bool abortFlg = false;

        public EQPretender()
        {
        }

        //Pretend logic 
        public string pretendResponse(string request, string response)
        {
            if (request.Contains(":q1010000") && response.StartsWith("="))
            {
                //Pretend EQ Mode
                int s = 0;
                if (int.TryParse(response.Substring(2, 1), out s))
                {
                    s = s | 0b00001000;//EQ Mode support is 2nd letter, Bit 3 
                }
                response = response.Substring(0, 2) + s.ToString() + response.Substring(3);
            }
            else if (request.Contains(":X20002") && response.StartsWith("="))
            {
                //Pretend DEC axis rotate direction 
                //Invert Sign: example 000F865B => FFF079A5
                string hexString = response.Replace("=", "").Replace("\r", "").Replace("\n", "");
                int intValue = Convert.ToInt32(hexString, 16);
                int signedIntValue = 0;
                unchecked
                {
                    signedIntValue = (int)intValue;
                }
                signedIntValue *= -1;
                string hexStringInv = signedIntValue.ToString("X8");
                response = "=" + hexStringInv + "\r";
            }
            return response;
        }


        public void Start(string cType, string connectionStr)
        {
            abortFlg = false;
            string ERROR_RESPONSE = Encoding.ASCII.GetString(new byte[] { 0x0d, 0x0a, 0x0d, 0x0a, 0x45, 0x52, 0x52, 0x4f, 0x52, 0x0d, 0x0a });

            //Connect to Traverse
            mount = new Communicator(cType, connectionStr);

            //Server to SynScanApp
            Thread appListener = new Thread(new ThreadStart(() =>
            {
                using (UdpClient appUdp = new UdpClient(CONSTANTS.SKYWATCHER_PORT))
                {
                    appUdp.Client.ReceiveTimeout = 1000;
                    while (!abortFlg)
                    {
                        IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, CONSTANTS.SKYWATCHER_PORT);
                        byte[] receivedBytes;
                        try
                        {
                            receivedBytes = appUdp.Receive(ref remoteEndPoint);
                            string receivedData = Encoding.ASCII.GetString(receivedBytes);
                            Console.WriteLine(receivedData);
                            IPAddress senderAddress = remoteEndPoint.Address;
                            int senderPort = remoteEndPoint.Port;
                            {

                                string response = "";
                                if (receivedData.Contains("AT + CWMODE_CUR"))//Ignore this command
                                {
                                    response = ERROR_RESPONSE;
                                }
                                else
                                {
                                    try
                                    {
                                        response = mount.SendAndReceive(receivedData);//Forward to the Mount, and get response
                                        response = pretendResponse(receivedData, response);
                                    }
                                    catch (TimeoutException timeex)
                                    {
                                        response = ERROR_RESPONSE;
                                    }
                                    catch (SocketException sockex)
                                    {
                                        response = ERROR_RESPONSE;
                                    }
                                }
                                byte[] sendData = Encoding.ASCII.GetBytes(response);
                                appUdp.Send(sendData, sendData.Length, senderAddress.ToString(), senderPort);
                            }
                        }
                        catch (TimeoutException timeex)
                        {
                        }
                        catch (SocketException soex)
                        {
                        }
                    }
                }
            }));
            appListener.Start();
        }

        public void Stop()
        {
            if (mount != null)
            {
                mount.abort();
            }
            abortFlg = true;
        }
    }
}
