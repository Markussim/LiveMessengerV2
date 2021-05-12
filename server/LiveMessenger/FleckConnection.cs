using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fleck;

namespace LiveMessenger
{
    public class FleckConnection
    {
        private static Room room = new Room("coolBre");
        public static void start()
        {
            var server = new WebSocketServer("ws://0.0.0.0:5001");
            server.Start(socket =>
            {
                socket.OnOpen = () =>
                {
                    System.Console.WriteLine("Connection opened!\n" + socket.ConnectionInfo.Path);
                    room.Subscribe(new ClientConnection(room, socket));

                };
                socket.OnClose = () =>
                {
                    Console.WriteLine("Connection closed");
                };
            });
        }
    }
}