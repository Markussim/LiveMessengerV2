using MongoDB.Driver;

namespace LiveMessenger
{
    public class RoomModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        [BsonElement("RoomModel")]
        public string Name { get; set; }

        public string Description { get; set; }

        public List<MessageModel> Messages { get; set; }

        abstract createRoom(){

        }
    }
}
