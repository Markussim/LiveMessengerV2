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
            Name = nameIN.Length > 15 ? nameIN.Substring(0, 15) : nameIN; //Cuts the Name at 15
            Description = descriptionIN.Length > 70 ? descriptionIN.Substring(0, 70) : descriptionIN; //Cuts the Description at 70
            Password = passwordIN.Length > 69 ? passwordIN.Substring(0, 69) : passwordIN; //Cuts the Password at 69
            Private = true;
        }

        public override void CreateRoom() //Saves the Private Room to MongoDB in the collection Rooms. 
        {
            var collection = ConnectToDB.db.GetCollection<RoomModel>("Rooms");
            collection.InsertOne(this);
        }
    }
}
