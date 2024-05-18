using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace eqPretender
{
    public class UdpCommunication : ICommunication
    {
        private UdpClient udpClient;
        private IPEndPoint remoteEP;

        public void Initialize(string endpoint)
        {
            udpClient = new UdpClient();
            udpClient.Client.ReceiveTimeout = 200;
            remoteEP = new IPEndPoint(IPAddress.Parse(endpoint), CONSTANTS.SKYWATCHER_PORT);
        }

        public string SendAndReceive(string message)
        {
            string receivedData = "";
            try
            {
                byte[] sendBytes = Encoding.ASCII.GetBytes(message);
                udpClient.Send(sendBytes, sendBytes.Length, remoteEP);

                byte[] receivedBytes = udpClient.Receive(ref remoteEP);
                receivedData = Encoding.ASCII.GetString(receivedBytes);
            }
            //catch(TimeoutException tex)
            //catch (SocketException soe)
            catch (Exception e)
            {
            }
            return receivedData;
        }

        public void abort()
        {
            try
            {
                udpClient.Close();
            }catch(Exception e) { 
            }
        }
    }
}
