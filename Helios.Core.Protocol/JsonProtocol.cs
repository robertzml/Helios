using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helios.Model;
using Newtonsoft.Json;

namespace Helios.Core.Protocol
{
    /// <summary>
    /// Json协议
    /// </summary>
    public class JsonProtocol
    {
        #region Method
        public bool ParseMessage(byte[] message)
        {
            var head = message.Take(4);
            if (head.Any(r => r != 0xA5))
                return false;

            byte[] bcount = message.Skip(4).Take(2).ToArray();
            int count = (bcount[0] << 8) + bcount[1];

            string json = Encoding.ASCII.GetString(message, 6, count);

            byte[] crc = message.Skip(6 + count).ToArray();

            return true;
        }

        public ReportMessage GetReport(string message)
        {
            var data = JsonConvert.DeserializeObject<ReportMessage>(message);
            return data;
        }
        #endregion //Method
    }
}
