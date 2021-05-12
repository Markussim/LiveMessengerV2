using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LiveMessenger.Pages
{
    public class IndexModel : PageModel
    {
        public List<BsonDocument> Rooms { get; set; }

        public string Username { get; set; }
        public IActionResult OnGet()
        {
            if (!CheckCookie.checkUsername(Request)) return Redirect("ChangeUsername");
            Username = Request.Cookies["username"];
            Rooms = GetRoom.RetrieveAllRooms();
            return null;
        }
    }
}
    