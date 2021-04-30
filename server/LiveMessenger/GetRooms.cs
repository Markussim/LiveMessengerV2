using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace LiveMessenger
{
    public class GetRooms
    {
        public static List<BsonDocument> RetrieveRooms()
        {
            var collection = connectToDB.db.GetCollection<BsonDocument>("Rooms");
            return collection.Find(new BsonDocument()).ToList();
        }
    }
}