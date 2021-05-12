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
    public class PasswordCheckModel : PageModel
    {

        public IActionResult OnGet()
        {
            if (!CheckCookie.checkUsername(Request)) return Redirect("ChangeUsername");
            String id = Request.Query["id"];
            if (!CheckRoom.byID(id)) return Redirect("/");
            return null;
        }
        public IActionResult OnPost(string password)
        {
            String id = Request.Query["id"];
            System.Console.WriteLine(password);
            if(CheckPassword.isCorrect(password, id)) {
                Response.Cookies.Append(id, password);
                return Redirect($"/Chat?id={id}");
            }
            return null;
        }
    }
}
