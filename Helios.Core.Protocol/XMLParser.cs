using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Helios.Model;

namespace Helios.Core.Protocol
{
    /// <summary>
    /// XML 解析类
    /// </summary>
    public class XmlParser
    {
        #region Field
        private XmlDocument doc;
        #endregion //Field

        #region Constructor
        public XmlParser(string text)
        {
            this.doc = new XmlDocument();

            byte[] array = Encoding.ASCII.GetBytes(text);
            MemoryStream stream = new MemoryStream(array);
            StreamReader sr = new StreamReader(stream);

            XmlReaderSettings setting = new XmlReaderSettings();
            setting.IgnoreComments = true;

            XmlReader reader = XmlReader.Create(sr, setting);
            doc.Load(reader);
            reader.Close();
        }
        #endregion //Constructor

        #region Function
        private DataTable GetData(string xmlPathNode)
        {
            try
            {
                DataSet ds = new DataSet();
                StringReader read = new StringReader(doc.SelectSingleNode(xmlPathNode).OuterXml);
                ds.ReadXml(read);
                return ds.Tables[0];
            }
            catch (Exception)
            {
                return new DataTable();
            }
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 获取Common节
        /// </summary>
        /// <returns></returns>
        public MessageCommonSection GetCommon()
        {
            var node = this.doc.SelectSingleNode("root/common");

            MessageCommonSection data = new MessageCommonSection();
            data.GatewayId = node.SelectSingleNode("gateway_id").InnerText;
            string type = node.SelectSingleNode("type").InnerText;

            switch (type)
            {
                case "heart_beat":
                    data.Type = MessageType.HeartBeat;
                    break;
                case "report":
                    data.Type = MessageType.Report;
                    break;
                default:
                    data.Type = MessageType.Unknown;
                    break;
            }

            return data;
        }

        /// <summary>
        /// 解析心跳报文
        /// </summary>
        /// <param name="gatewayId">网关ID</param>
        /// <returns></returns>
        public HeartBeatMessage ParseHeartBeat(string gatewayId)
        {
            var node = this.doc.SelectSingleNode("root/heart_beat");

            HeartBeatMessage message = new HeartBeatMessage();
            message.GatewayId = gatewayId;
            message.BeatTime = node.Attributes["time"].Value;
            message.Meters = new List<long>();

            foreach (XmlNode item in node.ChildNodes)
            {
                long mid = Convert.ToInt64(item.Attributes["id"].Value);
                message.Meters.Add(mid);
            }

            return message;
        }

        /// <summary>
        /// 解析上报数据
        /// </summary>
        /// <param name="gatewayId">网关ID</param>
        /// <returns></returns>
        public ReportMessage ParseReport(string gatewayId)
        {
            var node = this.doc.SelectSingleNode("root/data");

            ReportMessage message = new ReportMessage();
            message.GatewayId = gatewayId;
            message.Sequence = node.SelectSingleNode("sequence").InnerText;
            message.Time = DateTime.ParseExact(node.SelectSingleNode("time").InnerText, "yyyyMMddHHmmss", null);
            message.Meters = new List<MeterParameter>();

            var meters = node.SelectNodes("meter");
            foreach (XmlNode item in meters)
            {
                MeterParameter m = new MeterParameter();
                m.Id = Convert.ToInt32(item.Attributes["id"].Value);
                m.Tags = new Dictionary<string, double>();
                var tags = item.SelectNodes("tag");
                foreach (XmlNode tag in tags)
                {
                    m.Tags.Add(tag.Attributes["id"].Value, Convert.ToDouble(tag.InnerText));
                }

                message.Meters.Add(m);
            }

            return message;
        }
        #endregion //Method
    }
}
