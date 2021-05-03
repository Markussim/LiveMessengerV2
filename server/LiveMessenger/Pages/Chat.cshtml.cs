using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LiveMessenger;

namespace LiveMessenger.Pages
{
    public class ChatModel : PageModel
    {
        public IActionResult OnGet()
        {
            if (!checkCookie.checkUsername(Request)) return Redirect("ChangeUsername");
            String id = Request.Query["id"];
            return null;
        }
        public void OnPost()
        {
        }
    }
}
