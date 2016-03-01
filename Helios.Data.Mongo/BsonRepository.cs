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

        public long Update(string collectionName, FilterDefinition<BsonDocument> filter, UpdateDefinition<BsonDocument> update, bool upsert)
        {
            var collection = this.database.GetCollection<BsonDocument>(collectionName);
            var options = new UpdateOptions { IsUpsert = upsert };

            var result = collection.UpdateOne(filter, update, options);

            return result.ModifiedCount;
        }
        #endregion //Method
    }
}
