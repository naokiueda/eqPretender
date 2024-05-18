using System;
using System.Windows.Forms;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace eqPretender
{
    public partial class eqPretenderScreen : Form
    {
        private EQPretender eqpt;
        private string cType;
        private bool isRunning;
        public eqPretenderScreen()
        {
            InitializeComponent();
            isRunning = false;
            eqpt = new EQPretender();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            restoreSetting();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            eqpt.Stop();
            isRunning = false;
        }


        private void restoreSetting()
        {
            var cTypeSelected = Properties.Settings.Default["cTypeSelected"] as string;
            radio_network.Checked = (cTypeSelected == "N");
            radio_serial.Checked = (cTypeSelected == "S");
            //IP
            
            //////SerialPorts lists
            string[] portNames = System.IO.Ports.SerialPort.GetPortNames();
            comboBox_serial_comname.Items.Clear();

            string saved = Properties.Settings.Default["ComportName"].ToString();
            int selectedIndex = -1;
            for (int i = 0; i < portNames.Length; i++)
            {
                if (portNames[i].Trim() == saved.Trim())
                {
                    selectedIndex = i;
                }
                comboBox_serial_comname.Items.Add(portNames[i]);
            }
            comboBox_serial_comname.SelectedIndex = selectedIndex;


            ////////UDP List
            //byte[] sendBytes = Encoding.ASCII.GetBytes(":e1\r");
            //using (UdpClient client = new UdpClient())
            //{
            //    string destIp = "255.255.255.255";//Broadcast
            //    client.EnableBroadcast = true;
            //    try
            //    {
            //        client.Send(sendBytes, sendBytes.Length, destIp, CONSTANTS.SKYWATCHER_PORT);
            //    }
            //    catch (Exception e)
            //    {
            //    }
            //    DateTime datetimeSentBroadcast = DateTime.Now;
            //    comboBox_network_ip.Items.Clear();
            //    comboBox_network_ip.SelectedIndex = -1;
            //    client.Client.ReceiveTimeout = 200;
            //    while ((DateTime.Now - datetimeSentBroadcast).TotalMilliseconds < 1000)
            //    {
            //        IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, CONSTANTS.SKYWATCHER_PORT);
            //        byte[] receivedBytes;
            //        try
            //        {
            //            receivedBytes = client.Receive(ref remoteEndPoint);
            //        }catch(TimeoutException tex)
            //        {
            //            System.Threading.Thread.Sleep(100);
            //            continue;
            //        }catch(SocketException soex)
            //        {
            //            System.Threading.Thread.Sleep(100);
            //            continue;

            //        }
            //        string receivedData = Encoding.ASCII.GetString(receivedBytes);
            //        IPAddress senderAddress = remoteEndPoint.Address;
            //        if (receivedData.StartsWith("=") && receivedData.EndsWith("\r") && receivedData.Length == 8)
            //        {
            //            comboBox_network_ip.Items.Add(senderAddress.ToString());
            //        }
            //    }
            //    string savedIp = Properties.Settings.Default["mountIp"].ToString();
            //    for (int i=0; i<comboBox_network_ip.Items.Count; i++)
            //    {
            //        if(comboBox_network_ip.Items[i].ToString().Trim() == savedIp.Trim())
            //        {
            //            selectedIndex = 1;
            //        }
            //    }
            //    if (selectedIndex == -1)
            //    {
            //        comboBox_network_ip.Text = savedIp!=""?savedIp:CONSTANTS.SKYWATCHER_DEFAULT_IP;                 
            //    }
            //}

            //VIsibility            
            comboBox_network_ip.Visible = radio_network.Checked;
            comboBox_serial_comname.Visible = radio_serial.Checked;
        }
        private void saveSetting()
        {
            Properties.Settings.Default["cTypeSelected"] = cType;
            Properties.Settings.Default["mountIp"] = comboBox_network_ip.Text;
            Properties.Settings.Default["ComportName"] = comboBox_serial_comname.Text;
            Properties.Settings.Default.Save();
        }

        private void radios_Click(object sender, EventArgs e)
        {
            comboBox_network_ip.Visible = radio_network.Checked;
            comboBox_serial_comname.Visible = radio_serial.Checked;
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                //Stop
                eqpt.Stop();
                isRunning = false;
                label_running_status.Text = "Stopped.";
                button_run.Text = "Run";
            }
            else
            {
                //Start
                string connectionStr = ""; ;
                if (radio_network.Checked)
                {
                    cType = "N";
                    connectionStr = comboBox_network_ip.Text;
                }
                else
                {
                    cType = "S";
                    connectionStr = comboBox_serial_comname.Text;
                }
                saveSetting();
                eqpt.Start(cType, connectionStr);
                isRunning = true;
                label_running_status.Text = "Running..";
                button_run.Text = "Stop";
            }

        }
    }
}
