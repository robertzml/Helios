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
            string data;
            using (var reader = new StreamReader("xintiao.xml"))
            {
                data = reader.ReadToEnd();
            }
            Send(data);
        }
        

        private void buttonParse_Click(object sender, EventArgs e)
        {
            string data;
            using (var reader = new StreamReader("shangbao.xml"))
            {
                data = reader.ReadToEnd();
            }

            XmlProtocol protocol = new XmlProtocol();
            var common = protocol.ReadCommon(data);
            ReportMessage message = (ReportMessage)protocol.ReadBody(common, data);

            this.textBoxMessageOutput.AppendText(string.Format("gateway id: {0}, sequence: {1}, \r\n time: {2}\r\n", 
                message.GatewayId, message.Sequence, message.Time));

            foreach(var meter in message.Meters)
            {
                this.textBoxMessageOutput.AppendText(string.Format("meter id: {0}", meter.Id));
                foreach(var tag in meter.Tags)
                {
                    this.textBoxMessageOutput.AppendText(string.Format("{0}: {1} \t", tag.Key, tag.Value));
                }
            }

            EnergyBusiness business = new EnergyBusiness();
            business.AddEnergy(message);
        }
        

        private void buttonHeartBeat_Click(object sender, EventArgs e)
        {
            string data;
            using (var reader = new StreamReader("xintiao.xml"))
            {
                data = reader.ReadToEnd();
            }

            XmlProtocol protocol = new XmlProtocol();
            var common = protocol.ReadCommon(data);
            HeartBeatMessage message = (HeartBeatMessage)protocol.ReadBody(common, data);

            HeartBeatBusiness business = new HeartBeatBusiness();
            business.UpdateHeartBeat(message);

        }
        #endregion //Event
    }
}
