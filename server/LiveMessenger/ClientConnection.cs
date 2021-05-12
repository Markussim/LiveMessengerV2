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
        public Room room { get; set; }

        public IWebSocketConnection socket { get; set; }

        public ClientConnection(Room roomIN, IWebSocketConnection socketIN)
        {
            room = roomIN;
            socket = socketIN;
            receiveMessage();
        }

        public void receiveMessage()
        {
            socket.OnMessage = message => room.Notify(message, room);
        }

        public void sendMessage(string message)
        {
            socket.Send(message);
        }
    }
}