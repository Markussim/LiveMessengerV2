using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.Generic;

namespace LiveMessenger
{
    public class PrivateRoomModel : RoomModel
    {
        public string Password { get; set; }
        public bool privateRoom { get; set; }


        public PrivateRoomModel(string nameIN, string descriptionIN, string passwordIN)
        {
            Name = nameIN;
            Description = descriptionIN;
            Password = passwordIN;
            privateRoom = true;
        }

        public override void CreateRoom()
        {
            var collection = ConnectToDB.db.GetCollection<RoomModel>("Rooms");
            collection.InsertOne(this);
        }
    }
}
