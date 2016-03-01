using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helios.Model;
using Helios.Data.Mongo;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Helios.Business
{
    /// <summary>
    /// 心跳业务
    /// </summary>
    public class HeartBeatBusiness
    {
        /// <summary>
        /// 更新心跳记录
        /// </summary>
        /// <param name="data">心跳报文</param>
        public void UpdateHeartBeat(HeartBeatMessage data)
        {
            BsonRepository repository = new BsonRepository();

            foreach (var meter in data.Meters)
            {
                var filter = Builders<BsonDocument>.Filter.Eq("meterId", meter);
                var update = Builders<BsonDocument>.Update.Set("gatewayId", data.GatewayId).Set("time", data.BeatTime);

                repository.Update("heartBeat", filter, update, true);
            }
        }
    }
}
