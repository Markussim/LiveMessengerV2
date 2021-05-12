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
using System.Net.WebSockets;

namespace LiveMessenger
{

    public class ClientConnection
    {
        public Room room { get; set; }

        public ClientConnection(Room roomIN)
        {
            room = roomIN;
        }
        public void Startup()
        {

        }

        public void receiveMessage()
        {

        }

        public void sendMessage(string message)
        {

        }
    }
}