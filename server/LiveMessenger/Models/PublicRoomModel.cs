using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.Generic;

namespace LiveMessenger
{
    public class PublicRoomModel : RoomModel
    {

        public PublicRoomModel(string nameIN, string descriptionIN)
        {
            Name = nameIN;
            Description = descriptionIN;
        }
        
        public override void CreateRoom()
        {
            var collection = ConnectToDB.db.GetCollection<RoomModel>("Rooms");
            collection.InsertOne(this);
        }
    }
}
