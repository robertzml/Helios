using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Helios.Model;

namespace Helios.Core.Protocol
{
    /// <summary>
    /// 消息处理委托
    /// </summary>
    /// <param name="message"></param>
    public delegate void ProcessInvoke(IMessage message);

    public delegate void ProcessInvokeSimple(string message);

    /// <summary>
    /// UDP服务器类
    /// </summary>
    public class UdpServer
    {
        #region Field
        /// <summary>
        /// IP
        /// </summary>
        private string ip = "210.28.24.247";

        /// <summary>
        /// 端口
        /// </summary>
        private int listenPort = 11000;

        private GatewayProtocol protocol = new GatewayProtocol();

        private ProcessInvokeSimple invokeSimple;

        private ProcessInvoke invoke;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// UDP服务器
        /// </summary>
        public UdpServer()
        { }

        /// <summary>
        /// UDP服务器
        /// </summary>
        /// <param name="ip">IP</param>
        /// <param name="port">端口</param>
        public UdpServer(string ip, int port)
        {
            this.ip = ip;
            this.listenPort = port;
        }

        #region Method
        /// <summary>
        /// 设置回调
        /// </summary>
        /// <param name="invoke"></param>
        public void SetInvoke(ProcessInvoke invoke)
        {
            this.invoke = invoke;
        }

        public void SetInvokeSimple(ProcessInvokeSimple simple)
        {
            this.invokeSimple = simple;
        }

        /// <summary>
        /// 启动服务
        /// </summary>
        /// <param name="obj"></param>
        public void Start(object obj)
        {
            bool done = false;

            IPAddress ipAddress = IPAddress.Parse(this.ip);
            IPEndPoint ipLocalEndPoint = new IPEndPoint(ipAddress, listenPort);

            UdpClient listener = new UdpClient(ipLocalEndPoint);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);

            try
            {
                invokeSimple("Waiting for broadcast");

                while (!done)
                {
                    byte[] bytes = listener.Receive(ref groupEP);

                    string clientIP = groupEP.ToString();
                    string message = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                    invokeSimple(message);

                    this.protocol.ParseMessage(message);
                    var formatMessage = this.protocol.ReadHeartBeat();

                    invoke(formatMessage);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                listener.Close();
            }
        }
        #endregion //Method
        #endregion //Constructor
    }
}
