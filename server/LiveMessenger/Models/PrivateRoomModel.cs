using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.Generic;

namespace LiveMessenger
{
    public class PrivateRoomModel : RoomModel //Class that inherits from RoomModel
    {
        public string Password { get; set; }

        public PrivateRoomModel(string nameIN, string descriptionIN, string passwordIN) // Contstructor for PrivateRoomModel. Sets the variables to input
        {
            Name = nameIN;
            Description = descriptionIN;
            Password = passwordIN;
            Private = true;
        }

        public override void CreateRoom() //Saves the Private Room to MongoDB in the collection Rooms. 
        {
            var collection = ConnectToDB.db.GetCollection<RoomModel>("Rooms");
            collection.InsertOne(this);
        }
    }
}
