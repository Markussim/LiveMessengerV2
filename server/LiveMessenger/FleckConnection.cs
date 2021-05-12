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
        private static List<Room> rooms = new List<Room>();
        public static void start()
        {
            var server = new WebSocketServer("ws://0.0.0.0:5001");
            server.Start(socket =>
            {
                socket.OnOpen = () =>
                {
                    string roomID = socket.ConnectionInfo.Path.Substring(1);
                    bool existingRoom = false;
                    int roomIndex = 0;
                    for (int i = 0; i < rooms.Count; i++)
                    {
                        if (rooms[i].roomID == roomID)
                        {
                            existingRoom = true;
                            roomIndex = i;
                            break;
                        }
                    }
                    if (!existingRoom && CheckRoom.byID(roomID))
                    {
                        rooms.Add(new Room(roomID));
                        roomIndex = rooms.Count - 1;
                    }

                    System.Console.WriteLine("Connection opened!");
                    rooms[roomIndex].Subscribe(new ClientConnection(rooms[roomIndex], socket));

                };
                socket.OnClose = () =>
                {
                    Console.WriteLine("Connection closed");
                };
            });
        }
    }
}