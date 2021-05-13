using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Globalization;

namespace LiveMessenger
{
    public class MessageModel
    {
        public string User { get; set; }

        public string Message { get; set; }

        public string Room { get; set; }

        public DateTime Date { get; set; }

        public MessageModel(string UserIN, string MessageIN, string RoomIN){ // Contstructor for MessageModel. Sets the variables to input and sets Date to Current Date
            User = UserIN;
            Message = MessageIN;
            Room = RoomIN;
            Date = DateTime.Now;
        }

        public void SaveMessage() //Saves the current instance of the MessageModel to MongoDB in the collection Messages
        {
            var collection = ConnectToDB.db.GetCollection<MessageModel>("Messages");
            collection.InsertOne(this);
        }
    }
}