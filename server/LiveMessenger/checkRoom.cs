using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Net;

namespace LiveMessenger
{
    public class CheckRoom
    {
        //Method checks if the input id is related to a existing room, if it is, the method returns true
        public static bool byID(string id)
        {
            try
            {
                bool validRoom = true;
                var collection = ConnectToDB.db.GetCollection<BsonDocument>("Rooms");
                var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
                var document = collection.Find(filter).FirstOrDefault();
                if (document == null) validRoom = false;
                return validRoom;
            }
            catch (System.Exception)
            {

                return false;
            }
        }
    }
}
