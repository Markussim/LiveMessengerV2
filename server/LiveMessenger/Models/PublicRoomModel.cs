using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.Generic;

namespace LiveMessenger
{
    public class PublicRoomModel : RoomModel //Class that inherits from RoomModel
    {

        public PublicRoomModel(string nameIN, string descriptionIN) // Contstructor for PublicRoomModel. Sets the variables to input
        {
            Name = nameIN.Length > 15 ? nameIN.Substring(0, 15) : nameIN; //Cuts the Name at 15
            Description = descriptionIN.Length > 70 ? descriptionIN.Substring(0, 70) : descriptionIN; //Cuts the Description at 70
            Private = false;
        }

        public override void CreateRoom() //Saves the Public Room to MongoDB in the collection Rooms. 
        {
            var collection = ConnectToDB.db.GetCollection<RoomModel>("Rooms");
            collection.InsertOne(this);
        }
    }
}
