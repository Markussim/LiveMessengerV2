using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LiveMessenger;

namespace LiveMessenger.Pages
{
    public class ChangeUsernameModel : PageModel
    {
        public void OnGet()
        {
        }
        public IActionResult OnPost(string username)
        {

            if (!string.IsNullOrWhiteSpace(username))
            {
                username = username.Length > 15 ? username.Substring(0, 15) : username; //Cuts the username at 15
                username.Trim();
                Response.Cookies.Append("username", username, new Microsoft.AspNetCore.Http.CookieOptions
                {
                    Expires = DateTimeOffset.Now.AddYears(69) //nice
                });
            }
            return Redirect("/");

        }
    }
}
