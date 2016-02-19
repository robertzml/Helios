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
        /// 心跳报文
        /// </summary>
        [Display(Name = "心跳报文", ShortName = "heart_beat")]
        HeartBeat = 1
    }
}
