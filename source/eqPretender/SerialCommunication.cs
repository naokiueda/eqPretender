using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace eqPretender
{
    public class SerialCommunication : ICommunication
    {

        private SerialPort port;
        public void Initialize(string endpoint)
        {
            if (port != null)
            {
                if (port.IsOpen)
                {
                    port.Close();
                }
            }
            int timeout = 200;
            int maxBaudRate = 115200;
            try
            {
                port = new SerialPort(endpoint, maxBaudRate);
                port.ReadTimeout = timeout;
                port.WriteTimeout = timeout;
                port.Open();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message, "ERROR", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        public string SendAndReceive(string message)
        {
            port.Write(message);
            try
            {
                int idx = 0;
                byte[] res = new byte[256];
                byte b = (byte)port.ReadByte();
                idx++;
                while (b != '\r')
                {
                    res[idx] = b;
                    b = (byte)port.ReadByte();
                    idx++;
                }
                res[idx] = (byte)'\r';
                string receivedData = Encoding.ASCII.GetString(res).Replace("\0", "");
                return (receivedData);
            }catch(TimeoutException ex)
            {
                return ("");
            }catch(Exception e)
            {
                return ("");
            }
        }
        public void abort()
        {
            if (port != null)
            {
                if (port.IsOpen)
                {
                    port.Close();
                }
            }
        }
    }
}
