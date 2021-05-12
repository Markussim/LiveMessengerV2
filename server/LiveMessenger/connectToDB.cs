using MongoDB.Bson;
using MongoDB.Driver;


namespace LiveMessenger
{
    public class ConnectToDB
    {

        public static MongoClient dbClient;
        public static IMongoDatabase db;

        public static void connectToMongo()
        {
            dbClient = new MongoClient("mongodb://localhost:27017/");
            db = dbClient.GetDatabase("LiveMessengerV2");

        }
    }
}