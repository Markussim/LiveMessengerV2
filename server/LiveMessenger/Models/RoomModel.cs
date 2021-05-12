using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.Generic;

namespace LiveMessenger
{
    public abstract class RoomModel
    {
        public bool Private { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public abstract void CreateRoom();
    }
}
