using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.Generic;

namespace LiveMessenger
{
    abstract class RoomModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        [BsonElement("RoomModel")]
        public string Name { get; set; }

        public string Description { get; set; }

        public List<MessageModel> Messages { get; set; }

        public abstract void CreateRoom();
    }
}
