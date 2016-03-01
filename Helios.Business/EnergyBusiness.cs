using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helios.Data.Mongo;
using Helios.Model;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Helios.Business
{
    /// <summary>
    /// 能耗数据业务类
    /// </summary>
    public class EnergyBusiness
    {
        #region Method
        public void AddEnergy(ReportMessage message)
        {
            BsonRepository repository = new BsonRepository();

            foreach (var meter in message.Meters)
            {
                var doc = new BsonDocument
                {
                    { "meterId", meter.Id },
                    { "gatewayId", message.GatewayId },
                    { "time", message.Time }
                };

                var tags = new BsonDocument();
                foreach(var tag in meter.Tags)
                {
                    tags.Add(new BsonElement(tag.Key, tag.Value));
                }

                doc.Add("tags", tags);

                repository.Insert(HeliosCollection.Energy, doc);
            }
        }
        #endregion //Method
    }
}
