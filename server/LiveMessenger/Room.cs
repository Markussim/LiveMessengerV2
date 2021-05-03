using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveMessenger
{
    public class Room
    {
        public string roomID;

        public Room(string roomIDIN)
        {
            roomID = roomIDIN;
        }
        private List<ClientConnection> clients = new List<ClientConnection>();
        public void Subscribe(ClientConnection client)
        {
            clients.Add(client);
            System.Console.WriteLine(("new client bre"));
            System.Console.WriteLine(clients.Count);
        }

        public void Notify(Byte[] message)
        {
            foreach (ClientConnection client in clients)
            {
                client.sendMessage(message);
            }
        }
    }
}
