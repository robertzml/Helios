using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helios.Data.Mongo
{
    /// <summary>
    /// Collection名称
    /// </summary>
    public class HeliosCollection
    {
        #region Field
        /// <summary>
        /// 心跳报文表
        /// heartBeat
        /// </summary>
        public static readonly string HeartBeat = "heatBeat";

        /// <summary>
        /// 能耗数据表
        /// energy
        /// </summary>
        public static readonly string Energy = "energy";
        #endregion //Field
    }
}
