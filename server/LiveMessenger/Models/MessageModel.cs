using MongoDB.Driver;

namespace LiveMessenger
{
    public class MessageModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        [BsonElement("MessageModel")]
        public string User { get; set; }

        public string Message { get; set; }

        public DateTime Date { get, set;}

        public MessageModel createMessage(string userIN, string messageIN){
            User = userIN;
            Message = messageIN;
        }
    }
}