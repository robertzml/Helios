using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Helios.Core.Protocol;
using Helios.Model;

namespace Helios.Test.ServerForm
{
    public partial class MainForm : Form
    {
        #region Field
        private UdpServer server;
        #endregion //Field

        #region Constructor
        public MainForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        private void ShowMessage(string message)
        {
            this.textBoxMessage.AppendText(message + "\r\n");
        }

        private void ShowFormatMessage(IMessage message)
        {
            HeartBeatMessage hb = (HeartBeatMessage)message;

            this.textBoxHeartBeat.AppendText(string.Format("Gateway: {0}, Time: {1}\r\n",
                hb.GatewayId, hb.BeatTime));

            foreach (var item in hb.Meters)
            {
                this.textBoxHeartBeat.AppendText(string.Format("Meter: {0}", item));
            }
        }
        #endregion //Function

        #region Event
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.server = new UdpServer();
            this.server.SetInvokeSimple(ShowMessage);
            this.server.SetInvoke(ShowFormatMessage);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(this.server.Start);
        }
        #endregion //Event
    }
}
