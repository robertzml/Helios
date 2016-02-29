using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helios.Model;

namespace Helios.Core.Protocol
{
    /// <summary>
    /// XML网关通讯协议
    /// </summary>
    public class XmlProtocol
    {
        #region Function
       
        #endregion //Function

        #region Constructor
        /// <summary>
        /// XML网关通讯协议
        /// </summary>
        /// <param name="message">报文数据</param>
        public XmlProtocol()
        {
         
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 读取Common节
        /// </summary>
        /// <param name="message">报文</param>
        /// <returns></returns>
        public MessageCommonSection ReadCommon(string message)
        {
            XmlParser parser = new XmlParser(message);
            var common = parser.GetCommon();
            return common;
        }

        public IMessage ReadBody(MessageCommonSection common, string message)
        {
            XmlParser parser = new XmlParser(message);
            switch (common.Type)
            {
                case MessageType.HeartBeat:
                    return parser.ParseHeartBeat(common.GatewayId);
                case MessageType.Report:
                    return parser.ParseReport(common.GatewayId);
            }

            return null;
        }

        /// <summary>
        /// 读取心跳报文
        /// </summary>
        /// <returns></returns>
        //public HeartBeatMessage ReadHeartBeat()
        //{
        //    return this.parser.ParseHeartBeat(common.GatewayId);
        //}

        ///// <summary>
        ///// 读取上报数据
        ///// </summary>
        ///// <returns></returns>
        //public ReportMessage ReadReport()
        //{
        //    return this.parser.ParseReport(common.GatewayId);
        //}
        #endregion //Method
    }
}
