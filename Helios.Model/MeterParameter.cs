using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helios.Model
{
    /// <summary>
    /// 电表参数
    /// </summary>
    public class MeterParameter
    {
        /// <summary>
        /// 电表ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 电表标签
        /// </summary>
        public Dictionary<string, double> Tags { get; set; }
    }
}
