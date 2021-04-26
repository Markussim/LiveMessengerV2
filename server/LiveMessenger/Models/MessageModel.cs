using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;

namespace LiveMessenger
{
    public class MessageModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        [BsonElement("MessageModel")]
        public string User { get; set; }

        public string Message { get; set; }

        public DateTime Date { get; set; }

        public MessageModel CreateMessage(string userIN, string messageIN)
        {
            MessageModel tmp = new MessageModel();
            User = userIN;
            Message = messageIN;
            return tmp;
        }
    }
}