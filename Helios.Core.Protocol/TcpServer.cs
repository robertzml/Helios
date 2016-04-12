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
    /// 处理服务器消息
    /// </summary>
    /// <param name="message">消息内容</param>
    public delegate void ProcessServerMessage(string message);

    /// <summary>
    /// TCP服务器类
    /// </summary>
    public class TcpServer
    {
        #region Field
        /// <summary>
        /// IP
        /// </summary>
        private string ip = "210.28.24.247";

        /// <summary>
        /// 端口
        /// </summary>
        private int port = 11000;

        /// <summary>
        /// TCP服务器
        /// </summary>
        private TcpListener server;

        /// <summary>
        /// 服务器消息处理
        /// </summary>
        private ProcessServerMessage invokeServerMessage;
        #endregion //Field

        #region Constructor
        public TcpServer()
        { }

        /// <summary>
        /// TCP服务器
        /// </summary>
        /// <param name="ip">IP</param>
        /// <param name="port">端口</param>
        public TcpServer(string ip, int port)
        {
            this.ip = ip;
            this.port = port;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 绑定消息处理回调
        /// </summary>
        /// <param name="invoke"></param>
        public void SetServerMessage(ProcessServerMessage invoke)
        {
            this.invokeServerMessage = invoke;
        }

        public void Start(object obj)
        {
            try
            {
                IPAddress ipAddress = IPAddress.Parse(this.ip);
            
                this.server = new TcpListener(ipAddress, port);

                // Start listening for client requests.
                server.Start();

                // Buffer for reading data
                byte[] bytes = new byte[30000];
                string data = null;

                JsonProtocol protocol = new JsonProtocol();

                // Enter the listening loop.
                while (true)
                {
                    //invokeServerMessage("Waiting for a connection... ");

                    // Perform a blocking call to accept requests.
                    // You could also user server.AcceptSocket() here.
                    TcpClient client = server.AcceptTcpClient();
                    //invokeServerMessage("Connected!");

                    data = null;

                    // Get a stream object for reading and writing
                    NetworkStream stream = client.GetStream();

                    int i;

                    // Loop to receive all the data sent by the client.
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {

                        //data = Encoding.ASCII.GetString(bytes, 0, i);
                        //invokeServerMessage(string.Format("Received: {0}", data));
                        protocol.ParseMessage(bytes, i);

                        // Process the data sent by the client.                       
                        string sendData = "hello, world";
                        byte[] msg = Encoding.ASCII.GetBytes(sendData);

                        // Send back a response.
                        stream.Write(msg, 0, msg.Length);
                        //invokeServerMessage(string.Format("Sent: {0}", sendData));
                    }

                    // Shutdown and end connection
                    client.Close();
                }
            }
            catch (SocketException e)
            {
                //invokeServerMessage(string.Format("SocketException: {0}", e));
            }
            finally
            {
                // Stop listening for new clients.
                server.Stop();
            }
        }
        #endregion //Method
    }
}
