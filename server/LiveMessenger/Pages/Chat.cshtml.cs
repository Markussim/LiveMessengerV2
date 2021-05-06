using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LiveMessenger;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace LiveMessenger.Pages
{
    public class ChatModel : PageModel
    {
        public IActionResult OnGet()
        {
            if (!checkCookie.checkUsername(Request)) return Redirect("ChangeUsername");
            String id = Request.Query["id"];
            if (!checkRoom.byID(id)) return Redirect("/");
            List<BsonDocument> previousMessages = GetPreviousMessages.RetrievePreviousMessages(id);
            previousMessages.ForEach(x => System.Console.WriteLine(x.GetElement("Message").Value));
            return null;
        }
        public void OnPost()
        {
        }
    }
}
