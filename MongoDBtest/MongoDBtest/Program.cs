using System;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;

namespace MongoDBtest
{
    class Program
    {

        private static readonly string stringBreak = "\n\n";
        private static readonly Action printBreak = () => Console.WriteLine(stringBreak); //misuse of Action
        static void Main(string[] args)
        {
            #region Beispiel_1 - Verbindungsaufbau + Datenbanknamen ausgeben
            MongoClient mc = new MongoClient("mongodb://localhost:27017");
            List<string> dbList = mc.ListDatabaseNames().ToList();
            dbList.ForEach(x => Console.WriteLine(x));
            printBreak();
            #endregion  Beispiel_1

            #region Beispiel_2 - DB anlegen
            IMongoDatabase mdb = mc.GetDatabase("MyNewDB"); //Erstellt neue DB, wenn diese noch nicht vorhanden ist
            #endregion

            #region Collection anlegen
            string myCollection = "SammlungA";
            try{
                mdb.CreateCollection(myCollection);
            }
            catch {
                Console.WriteLine("Collection '"+myCollection +"' existiert bereits.");
            };
            #endregion

            #region JSON-Datei einer Collection hinzufügen
            var collectionA = mdb.GetCollection<BsonDocument>(myCollection);
            var tmpDoc = new BsonDocument
            {
                { "myID", "123"},
                { "Name", "Test"},
                { "Attribut", "Einfach"}
            };
            collectionA.InsertOne(tmpDoc);
            #endregion

            #region JSON-Datei aus einer Collection holen
            var filter = Builders<BsonDocument>.Filter.Eq( "myID", "123");
            var myDoc = collectionA.Find(filter).FirstOrDefault();
            Console.WriteLine(myDoc.ToString());
            printBreak();
            #endregion

            #region Eintrag in einer JSON-Datei ändern
            var filter2 = Builders<BsonDocument>.Filter.Eq("Attribut", "Einfach");
            collectionA.DeleteOne(filter2);
            var update = Builders<BsonDocument>.Update.Set("Attribut","Schwer");
            //var filter3 = Builders<BsonDocument>.Filter.Eq("Attribut", "Schwer");  collectionA.DeleteOne(filter3);
            collectionA.UpdateOne(filter2, update);
            #endregion

            #region JSON-Dateien aus einer Collection ausgeben lassen
            var documents = collectionA.Find(new BsonDocument()).ToList();
            documents.ForEach(doc => Console.WriteLine(doc.ToString()));
            printBreak();
            #endregion

            #region Beispiel_2 - Importiere JSON in eine MongoDB-Collection
            /*
            //using MongoDB.Bson.IO;
            //using MongoDB.Bson.Serialization;
            //using MongoDB.Driver;

            string inputFileName = "H:\\Präsi_py\\Phillip\\sample.json";
            IMongoCollection<BsonDocument> collection = new IMongoCollectionBase<BsonDocument>; // initialize to the collection to write to.

            using (var streamReader = new StreamReader(inputFileName))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    using (var jsonReader = new JsonReader(line))
                    {
                        var context = BsonDeserializationContext.CreateRoot(jsonReader);
                        var document = collection.DocumentSerializer.Deserialize(context);
                        collection.InsertOne(document);
                    }
                }
            }
            */
            #endregion Beispiel_2 - 
        }
    }
}
