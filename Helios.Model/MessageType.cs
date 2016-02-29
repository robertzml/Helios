using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helios.Model
{
    /// <summary>
    /// 报文类型
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        /// 未知
        /// </summary>
        [Display(Name = "未知", ShortName = "unknown")]
        Unknown = 0,

        /// <summary>
        /// 心跳报文
        /// </summary>
        [Display(Name = "心跳报文", ShortName = "heart_beat")]
        HeartBeat = 1,

        /// <summary>
        /// 定时上报能耗数据报文
        /// </summary>
        [Display(Name = "定时上报", ShortName = "report")]
        Report = 2,

        /// <summary>
        /// 即抄应答报文
        /// </summary>
        [Display(Name = "即抄应答", ShortName = "reply")]
        Reply = 3,

        /// <summary>
        /// 变量写命令
        /// </summary>
        [Display(Name = "变量写命令", ShortName = "write")]
        Write = 4,

        /// <summary>
        /// 校时命令
        /// </summary>
        [Display(Name = "校时命令", ShortName = "timing")]
        Timing = 5,

        /// <summary>
        /// 周期上报命令下发
        /// </summary>
        [Display(Name = "周期上报命令下发", ShortName = "config")]
        Config = 6,

        /// <summary>
        /// 上传应答数据包
        /// </summary>
        [Display(Name = "上传应答数据包", ShortName = "data_ack_report")]
        DataAckReport = 7,

        /// <summary>
        /// 下行应答数据包
        /// </summary>
        [Display(Name = "下行应答数据包", ShortName = "data_ack_write")]
        DataAckWrite = 8,

        /// <summary>
        /// 主动即抄应答数据包
        /// </summary>
        [Display(Name = "下行应答数据包", ShortName = "data_ack_refresh")]
        DataAckRefresh = 9,

        /// <summary>
        /// 即抄命令
        /// </summary>
        [Display(Name = "即抄命令", ShortName = "refresh")]
        Refresh = 10
    }
}
