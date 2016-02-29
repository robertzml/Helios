using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Helios.Data.Mongo
{
    public class BsonRepository
    {
        #region Field
        private IMongoDatabase database;
        #endregion //Field

        #region Constructor
        public BsonRepository()
        {
            var url = new MongoUrl("mongodb://localhost");
            var client = new MongoClient(url);
            this.database = client.GetDatabase("helios");

        }
        #endregion //Constructor

        #region Method
        public void Insert(string collectionName, BsonDocument doc)
        {
            var collection = this.database.GetCollection<BsonDocument>(collectionName);

            collection.InsertOne(doc);
        }

        public void Update(string collectionName, BsonDocument filter, BsonDocument set, bool upsert)
        {
            var collection = this.database.GetCollection<BsonDocument>(collectionName);

            collection.UpdateOne(filter, set, new UpdateOptions { IsUpsert = upsert });
        }
        #endregion //Method
    }
}
