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
        private byte[] buffer = new byte[1024 * 4];

        private WebSocketReceiveResult result { get; set; }

        private WebSocket webSocket { get; set; }

        private HttpContext context { get; set; }

        private Room room { get; set; }

        public ClientConnection(WebSocket webSocketIN, HttpContext contextIN, Room roomIN)
        {
            webSocket = webSocketIN;
            context = contextIN;
            room = roomIN;
        }
        public async Task Startup()
        {
            //NEEDS TO SEND SOME FKN INIT THINGYHERE
            result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            await receiveMessage();
            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
        }

        public async Task receiveMessage()
        {
            while (!result.CloseStatus.HasValue)
            {
                System.Console.WriteLine(System.Text.Encoding.UTF8.GetString(buffer)); //prints message
                room.Notify(buffer);
                result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            }
        }

        public async Task sendMessage(Byte[] message) 
        {
            System.Console.WriteLine("new message to send bre");
            await webSocket.SendAsync(new ArraySegment<byte>(message, 0, result.Count), result.MessageType, result.EndOfMessage, CancellationToken.None);
        }

    }
}
