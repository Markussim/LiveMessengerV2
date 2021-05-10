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
        }

        public void Notify(Byte[] messageByte, Room room)
        {
            //messageByte = removeTrailingNulls(messageByte);
            if (System.Text.Encoding.UTF8.GetString(messageByte) != "")
            {
                MessageModel message = new MessageModel("user", System.Text.Encoding.UTF8.GetString(messageByte).Trim(), room.roomID);
                message.SaveMessage();
            }
            clients.ForEach(client => client.sendMessage(messageByte));
        }

        public byte[] removeTrailingNulls(Byte[] tmp)
        { 
            /*
            STOLEN FROM STACKOVERFLOWW
            https://stackoverflow.com/a/240745
            */
            int i = tmp.Length - 1;
            while (tmp[i] == 0)
                --i;
            byte[] tmp2 = new byte[i + 1];
            Array.Copy(tmp, tmp2, i + 1);
            return tmp2;
        }
    }
}
