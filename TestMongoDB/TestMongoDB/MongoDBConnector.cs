using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using System.Diagnostics;
using MongoDB.Bson;
using System.IO;

namespace TestMongoDB{
    class MongoDBConnector{

        /*Sources:
         https://zetcode.com/csharp/mongodb/
         Create json manually and use gui mongo-compass
        Create database from code
        https://putridparrot.com/blog/creating-a-simple-database-in-mongodb-with-c/#:~:text=%20Creating%20a%20simple%20database%20in%20MongoDB%20with,connect%20to%20the%20server%20and%20create%2Fuse...%20More%20
         */

        public class Person
        {
            public ObjectId Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
        }

        //MongoClient dbClient;
        public MongoDBConnector() {
            #region Verbindungsaufbau
            MongoClient dbClient = new MongoClient("mongodb://localhost:27017");
            var dbList = dbClient.ListDatabases().ToList();
            Trace.WriteLine("The list of databases on this server is: ");
            foreach (var db in dbList){
                Trace.WriteLine(db);
            }

            //Example1
            IMongoDatabase mdb = dbClient.GetDatabase("MyNewDB");
            var command = new BsonDocument { { "dbstats", 1 } };
            var result = mdb.RunCommand<BsonDocument>(command);
            Trace.WriteLine(result.ToJson());
            
            #endregion Verbindungsaufbau

            #region saveImage
            //legacy
            /*
            var server = MongoServer.Create("mongodb://localhost:27020");
            var database = server.GetDatabase("tesdb");

            var fileName = "D:\\Untitled.png";
            var newFileName = "D:\\new_Untitled.png";
            using (var fs = new FileStream(fileName, FileMode.Open))
            {
                var gridFsInfo = database.GridFS.Upload(fs, fileName);
                var fileId = gridFsInfo.Id;

                ObjectId oid = new ObjectId(fileId);
                var file = database.GridFS.FindOne(Query.EQ("_id", oid));

                using (var stream = file.OpenRead())
                {
                    var bytes = new byte[stream.Length];
                    stream.Read(bytes, 0, (int)stream.Length);
                    using (var newFs = new FileStream(newFileName, FileMode.Create))
                    {
                        newFs.Write(bytes, 0, bytes.Length);
                    }
                }
            }*/
            #endregion saveImage

            #region test (legacy)
            /*
            MongoClient client = new MongoClient();
            MongoServer server = client.GetServer();
            MongoDatabase testdb = server.GetDatabase("MyDatabase");
            MongoCollection<Person> collection = testdb.GetCollection<Person>("employees");

            Person p = new Person
            {
                Id = ObjectId.GenerateNewId(),
                FirstName = "Bob",
                LastName = "Baker",
                Age = 36
            };
            collection.Save(p);
            */
            #endregion test (legacy)

            #region import (Filter)
            /*Example2
            var cars = db.GetCollection<BsonDocument>("cars");
            var filter = Builders<BsonDocument>.Filter.Eq("price", 29000);
            var doc = cars.Find(filter).FirstOrDefault();
            Console.WriteLine(doc.ToString());
            */

            /*
            var documents = cars.Find(new BsonDocument()).ToList();
            foreach (BsonDocument doc in documents)
            {
                Console.WriteLine(doc.ToString());
            }*/

            /*
             var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Gt("price", 30000) & builder.Lt("price", 55000);

            var docs = cars.Find(filter).ToList();

            docs.ForEach(doc => {
                Console.WriteLine(doc);
            });
             */
            #endregion import (Filter)

            #region insert
            /*
             * var cars = db.GetCollection<BsonDocument>("cars");

            var doc = new BsonDocument
            {
                {"name", "BMW"},
                {"price", 34621}
            };

            cars.InsertOne(doc);
             */
            #endregion insert

            #region filter2
            //var docs = cars.Find(new BsonDocument()).Skip(3).Limit(3).ToList();

            //Projection: determine which fields are going to be included in the query output.
            //var docs = cars.Find(new BsonDocument()).Project("{_id: 0}").ToList();
            #endregion filter2

            #region update
            /*
             var dbClient = new MongoClient("mongodb://127.0.0.1:27017");

            IMongoDatabase db = dbClient.GetDatabase("testdb");

            var cars = db.GetCollection<BsonDocument>("cars");
            var filter = Builders<BsonDocument>.Filter.Eq("name", "BMW");

            cars.DeleteOne(filter);
             */
            /*
             var update = Builders<BsonDocument>.Update.Set("price", 52000);

            cars.UpdateOne(filter, update);
             */
            #endregion update
        }
    }
}
