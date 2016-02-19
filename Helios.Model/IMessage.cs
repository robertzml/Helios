using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helios.Model
{
    public interface IMessage
    {
        /// <summary>
        /// 获取消息类型
        /// </summary>
        /// <returns></returns>
        MessageType GetMessageType();
    }
}
