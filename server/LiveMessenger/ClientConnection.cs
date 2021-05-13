using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Threading;
using Fleck;

namespace LiveMessenger
{

    public class ClientConnection
    {
        public Room room { get; set; } //List of available rooms

        public IWebSocketConnection socket { get; set; }
        
        //Generates a new ClientConnection
        public ClientConnection(Room roomIN, IWebSocketConnection socketIN)
        {
            room = roomIN;
            socket = socketIN;
            receiveMessage();
        }

        //Method runs when a client recives a message and notifies the user
        public void receiveMessage()
        {
            socket.OnMessage = message => room.Notify(message, room);
        }

        //Method sends a string message
        public void sendMessage(string message)
        {
            socket.Send(message);
        }
    }
}