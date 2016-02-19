using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helios.Model
{
    /// <summary>
    /// 报文 common 节
    /// </summary>
    public class MessageCommonSection
    {
        /// <summary>
        /// 网关ID
        /// </summary>
        public string GatewayId { get; set; }

        /// <summary>
        /// 报文类型
        /// </summary>
        public MessageType Type { get; set; }
    }
}
