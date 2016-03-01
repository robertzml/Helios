using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helios.Model
{
    /// <summary>
    /// 心跳报文
    /// </summary>
    public class HeartBeatMessage : IMessage
    {
        #region Method
        public MessageType GetMessageType()
        {
            return MessageType.HeartBeat;
        }
        #endregion //Method

        #region Property
        /// <summary>
        /// 网关ID
        /// </summary>
        public string GatewayId { get; set; }

        /// <summary>
        /// 心跳时间
        /// </summary>
        public DateTime BeatTime { get; set; }

        /// <summary>
        /// 表具ID
        /// </summary>
        public List<long> Meters { get; set; }
        #endregion //Property
    }
}
