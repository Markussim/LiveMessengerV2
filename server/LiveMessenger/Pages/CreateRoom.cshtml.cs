using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LiveMessenger;

namespace LiveMessenger.Pages
{
    public class CreateRoomModel : PageModel
    {
        public IActionResult OnGet()
        {
            if (checkCookie.checkUsername(Request)) return Redirect("ChangeUsername");
            return null;
        }
        public IActionResult OnPost(string roomName, string description, string password)
        {
            if (Request.Cookies["username"] == null)
            {
                return Redirect("ChangeUsername");
            }
            else
            {
                if (password != null)
                {
                    System.Console.WriteLine("New private room \"" + roomName + "\" created!");
                    new PrivateRoomModel(roomName, description, password).CreateRoom();
                }
                else
                {
                    System.Console.WriteLine("New room \"" + roomName + "\" created!");
                    new PublicRoomModel(roomName, description).CreateRoom();
                }
                return Redirect("/");
            }

        }
    }
}
