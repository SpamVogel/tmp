using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;

namespace TestMongoDB
{
    class MongoDBConnector2
    {
        private static string connectionURI = "mongodb://localhost:27017";
        private static MongoDBConnector2 instance = null;
        private readonly MongoClient dbClient = new MongoClient(connectionURI);

        private MongoDBConnector2() { }
        public static MongoDBConnector2 getInstance() {
            if (instance == null) { instance = new MongoDBConnector2(); }
            return instance;
        }

        public MongoClient getDBClient() { return dbClient; }
        public static MongoClient getDBClient(String connectionURI) {
            return new MongoClient(connectionURI);
        }

        public List<BsonDocument> getDBlist() { return dbClient.ListDatabases().ToList(); }
        public static List<BsonDocument> getDBlist(MongoClient mc) {
            return mc.ListDatabases().ToList();
        }

        public IMongoDatabase getDB(String dbName){
            return dbClient.GetDatabase(dbName);
        }
        public static IMongoDatabase getDB(MongoClient mc, String dbName) {
            return mc.GetDatabase(dbName);
        }
        public BsonDocument getDBstats(String dbName){
            return getDBstats(dbClient, dbName);
        }
        public static BsonDocument getDBstats(MongoClient mc, String dbName) {
            var command = new BsonDocument { { "dbstats", 1 } };
            var result = (getDB(mc, dbName)).RunCommand<BsonDocument>(command);
            return result;
        }
    }
}
