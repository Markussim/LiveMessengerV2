using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LiveMessenger
{
    public class Room
    {
        public string roomID;

        //Constructor that sets the RoomID var.
        public Room(string roomIDIN)
        {
            roomID = roomIDIN;
        }
        private List<ClientConnection> clients = new List<ClientConnection>();

        //Functions that adds a ClientConnection to the List<>
        public void Subscribe(ClientConnection client)
        {
            clients.Add(client);
        }

        /*
         Function that parses the incomming JSON, creates MessageModel from information.
            Saves to MongoDB and creates JSON from MessageModel and send to all clients
        */
        public void Notify(string message, Room room)
        {
            JObject json = JObject.Parse(message); //parses JSON String from Client to Object¨
            if (!string.IsNullOrWhiteSpace(json.Property("message").Value.ToString()))
            {
                MessageModel msgModel = new MessageModel(json.Property("user").Value.ToString(), json.Property("message").Value.ToString(), room.roomID); //creates message model with Object
                msgModel.SaveMessage(); //saves model (the message) to MongoDB
                string msgJson = JsonConvert.SerializeObject(msgModel, Formatting.Indented); //converts Model to JSON
                clients.ForEach(client => client.sendMessage(msgJson)); //send JSON with WS to all clients
            }
        }

    }
}
