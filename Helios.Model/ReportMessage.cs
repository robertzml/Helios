using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Helios.Model
{
    /// <summary>
    /// 定时上报能耗数据
    /// </summary>
    public class ReportMessage : IMessage
    {
        #region Method
        public MessageType GetMessageType()
        {
            return MessageType.Report;
        }
        #endregion //Method

        #region Property
        /// <summary>
        /// 网关ID
        /// </summary>
        [JsonProperty("gateway", Required = Required.Always)]
        public string GatewayId { get; set; }

        [JsonProperty("type", Required = Required.Always)]
        public string Type { get; set; }

        /// <summary>
        /// 数据序号
        /// </summary>
        [JsonProperty("sequence", Required = Required.AllowNull)]
        public string Sequence { get; set; }

        /// <summary>
        /// 数据采集时间
        /// </summary>
        [JsonProperty("time", Required = Required.AllowNull)]
        public DateTime Time { get; set; }

        /// <summary>
        /// 电表数据
        /// </summary>
        public List<MeterParameter> Meters { get; set; }
        #endregion //Property
    }
}
