using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.Generic;

namespace LiveMessenger
{
    public abstract class RoomModel // Abstract class th
    {
        public bool Private { get; set; } //init of the varibles

        public string Name { get; set; }

        public string Description { get; set; }

        public abstract void CreateRoom(); // Init of the function CreateRoom()
    }
}
