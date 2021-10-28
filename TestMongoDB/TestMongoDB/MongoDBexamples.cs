using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;

namespace TestMongoDB
{
    class MongoDBexamples
    {
        MongoClient dbClient;

        public MongoDBexamples() {
        }

        public void init() {
            String dbConnectionURI = "mongodb://localhost:27017";
            dbClient = new MongoClient(dbConnectionURI);
        }

        public string bspDBliste() {
            var dbList = dbClient.ListDatabases().ToList();
            string s = "";
            foreach (var db in dbList)
            {
                s += db + "\n";
            }
            return s;
        }

        public string bspGetDB() {
            IMongoDatabase mdb = dbClient.GetDatabase("MyNewDB");
            var command = new BsonDocument { { "dbstats", 1 } };
            var result = mdb.RunCommand<BsonDocument>(command);
            return result.ToJson();
        }

    }
}
