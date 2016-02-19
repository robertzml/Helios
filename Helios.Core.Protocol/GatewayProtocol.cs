using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helios.Model;

namespace Helios.Core.Protocol
{
    /// <summary>
    /// 网关通讯协议
    /// </summary>
    public class GatewayProtocol
    {
        #region Function
        private XmlParser parser;

        private MessageCommonSection common;
        #endregion //Function

        #region Method
        public void ParseMessage(string message)
        {
            this.parser = new XmlParser(message);

            common = this.parser.GetCommon();
            //if (common.Type == "heart_beat")
            //    return 
        }

        public HeartBeatMessage ReadHeartBeat()
        {
            return this.parser.ParseHeartBeat(common.GatewayId);
        }
        #endregion //Method
    }
}
