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
        public List<BsonDocument> previousMessages { get; set; }
        public IActionResult OnGet()
        {
            if (!CheckCookie.checkUsername(Request)) return Redirect("ChangeUsername");
            String id = Request.Query["id"];
            if (!CheckRoom.byID(id)) return Redirect("/");
            previousMessages = GetPreviousMessages.RetrievePreviousMessages(id);
            return null;
        }
        public void OnPost()
        {
        }
    }
}
