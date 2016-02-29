using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string GatewayId { get; set; }

        /// <summary>
        /// 数据序号
        /// </summary>
        public string Sequence { get; set; }

        /// <summary>
        /// 数据采集时间
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// 电表数据
        /// </summary>
        public List<MeterParameter> Meters { get; set; }
        #endregion //Property
    }
}
