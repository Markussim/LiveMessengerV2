using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace LiveMessenger
{
    public class GetRoom
    {
        //Function that retrieves all entries in the MongoDB Collection "Rooms" without any filter
        public static List<BsonDocument> RetrieveAllRooms() 
        {
            var collection = ConnectToDB.db.GetCollection<BsonDocument>("Rooms");
            return collection.Find(new BsonDocument()).ToList();
        }

        //Function that retrieve on specific room with Filter of RoomID from the MongoDB Collection "Rooms"
        public static BsonDocument RetrieveOneRoom(string roomID){
            var collection = ConnectToDB.db.GetCollection<BsonDocument>("Rooms");
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(roomID));
            return collection.Find(filter).FirstOrDefault();
        }
    }
}