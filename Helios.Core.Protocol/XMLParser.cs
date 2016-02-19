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
            var dt = GetData("root/common");

            if (dt.Rows.Count == 0)
                return null;

            MessageCommonSection data = new MessageCommonSection();
            data.GatewayId = dt.Rows[0]["gateway_id"].ToString();
            string type = dt.Rows[0]["type"].ToString();

            switch (type)
            {
                case "heart_beat":
                    data.Type = MessageType.HeartBeat;
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
        #endregion //Method
    }
}
