using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Helios.Business;
using Helios.Model;
using Helios.Core.Protocol;

namespace Helios.Test.ClientForm
{
    public partial class MainForm : Form
    {
        #region Field
        /// <summary>
        /// 测试心跳数据
        /// </summary>
        private byte[] heartBeatData = new byte[] {
            0xA5, 0xA5, 0xA5, 0xA5, 0x00, 0x51, 0x7B, 0x22, 0x64, 0x61, 0x74, 0x61, 0x22, 0x3A, 0x7B, 0x22,
            0x74, 0x69, 0x6D, 0x65, 0x22, 0x3A, 0x22, 0x32, 0x30, 0x31, 0x36, 0x30, 0x33, 0x30, 0x33, 0x31,
            0x30, 0x30, 0x30, 0x32, 0x38, 0x22, 0x7D, 0x2C, 0x22, 0x67, 0x61, 0x74, 0x65, 0x77, 0x61, 0x79,
            0x22, 0x3A, 0x22, 0x31, 0x35, 0x30, 0x31, 0x31, 0x30, 0x30, 0x30, 0x30, 0x31, 0x22, 0x2C, 0x22,
            0x74, 0x79, 0x70, 0x65, 0x22, 0x3A, 0x22, 0x68, 0x65, 0x61, 0x72, 0x74, 0x5F, 0x62, 0x65, 0x61,
            0x74, 0x5F, 0x61, 0x63, 0x6B, 0x22, 0x7D, 0x0A, 0x2E
        };
        #endregion //Field

        #region Constructor
        public MainForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        private void Send(string text)
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            IPAddress broadcast = IPAddress.Parse("210.28.24.247");

            byte[] sendbuf = Encoding.ASCII.GetBytes(text);
            IPEndPoint ep = new IPEndPoint(broadcast, 11000);

            s.SendTo(sendbuf, ep);

            Console.WriteLine("Message sent to the broadcast address");
        }

        /// <summary>
        /// 连接tcp
        /// </summary>
        /// <param name="message"></param>
        private void Send2(string message)
        {
            try
            {
                // Create a TcpClient.
                int port = 11000;
                IPAddress ipAddress = IPAddress.Parse("210.28.24.247");
                //IPEndPoint ipLocalEndPoint = new IPEndPoint(ipAddress, port);

                TcpClient client = new TcpClient();
                client.Connect(ipAddress, port);

                // Translate the passed message into ASCII and store it as a Byte array.
                // byte[] data = Encoding.ASCII.GetBytes(message);

                // Get a client stream for reading and writing.
                // Stream stream = client.GetStream();
                NetworkStream stream = client.GetStream();

                // Send the message to the connected TcpServer. 
                stream.Write(this.heartBeatData, 0, this.heartBeatData.Length);

                this.textBoxMessage.AppendText("Message Sent.\r\n");

                // Receive the TcpServer.response.

                // Buffer to store the response bytes.
                byte[] receiveData = new byte[2000];

                // String to store the response ASCII representation.
                string responseData = string.Empty;

                // Read the first batch of the TcpServer response bytes.
                int bytes = stream.Read(receiveData, 0, receiveData.Length);
                responseData = System.Text.Encoding.ASCII.GetString(receiveData, 0, bytes);
                this.textBoxMessage.AppendText(string.Format("Received: {0}\r\n", responseData));

                // Close everything.
                stream.Close();
                client.Close();
            }
            catch (ArgumentNullException e)
            {
                this.textBoxMessage.AppendText(string.Format("ArgumentNullException: {0}", e));
            }
            catch (SocketException e)
            {
                this.textBoxMessage.AppendText(string.Format("SocketException: {0}", e));
            }
        }

        private void ShowFormatMessage(IMessage message)
        {
            HeartBeatMessage hb = (HeartBeatMessage)message;

            this.textBoxMessage.AppendText(string.Format("Gateway: {0}, Time: {1}\r\n",
                hb.GatewayId, hb.BeatTime));

            foreach (var item in hb.Meters)
            {
                this.textBoxMessage.AppendText(string.Format("Meter: {0}", item));
            }
        }
        #endregion //Funtion

        #region Event
        private void MainForm_Load(object sender, EventArgs e)
        {

        }


        private void buttonSend_Click(object sender, EventArgs e)
        {
            //string data;
            //using (var reader = new StreamReader("xintiao.xml"))
            //{
            //    data = reader.ReadToEnd();
            //}
            //Send(data);

            Send2("");
        }
        

        private void buttonParse_Click(object sender, EventArgs e)
        {
            //string data;
            //using (var reader = new StreamReader("shangbao.xml"))
            //{
            //    data = reader.ReadToEnd();
            //}

            //XmlProtocol protocol = new XmlProtocol();
            //var common = protocol.ReadCommon(data);
            //ReportMessage message = (ReportMessage)protocol.ReadBody(common, data);

            //this.textBoxMessageOutput.AppendText(string.Format("gateway id: {0}, sequence: {1}, \r\n time: {2}\r\n", 
            //    message.GatewayId, message.Sequence, message.Time));

            //foreach(var meter in message.Meters)
            //{
            //    this.textBoxMessageOutput.AppendText(string.Format("meter id: {0}", meter.Id));
            //    foreach(var tag in meter.Tags)
            //    {
            //        this.textBoxMessageOutput.AppendText(string.Format("{0}: {1} \t", tag.Key, tag.Value));
            //    }
            //}

            //EnergyBusiness business = new EnergyBusiness();
            //business.AddEnergy(message);
        }
        

        private void buttonHeartBeat_Click(object sender, EventArgs e)
        {
            //string data;
            //using (var reader = new StreamReader("xintiao.xml"))
            //{
            //    data = reader.ReadToEnd();
            //}

            //XmlProtocol protocol = new XmlProtocol();
            //var common = protocol.ReadCommon(data);
            //HeartBeatMessage message = (HeartBeatMessage)protocol.ReadBody(common, data);

            //HeartBeatBusiness business = new HeartBeatBusiness();
            //business.UpdateHeartBeat(message);

        }
       

        private void buttonReport2_Click(object sender, EventArgs e)
        {
            string data;
            using (var reader = new StreamReader("shangbao2.txt"))
            {
                data = reader.ReadToEnd();
            }

            JsonProtocol protocol = new JsonProtocol();
            var message = protocol.GetReport(data);

            this.textBoxMessageOutput.AppendText(string.Format("gateway id: {0}, time: {2}\r\n",
                message.GatewayId, message.Time));
        }
        #endregion //Event
    }
}
