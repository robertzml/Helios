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
        public ReportMessage GetReport(string message)
        {
            var data = JsonConvert.DeserializeObject<ReportMessage>(message);
            return data;
        }
        #endregion //Method
    }
}
