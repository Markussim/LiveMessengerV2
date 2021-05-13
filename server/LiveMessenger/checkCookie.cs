using Microsoft.AspNetCore.Http;
using System;
using System.Web;

namespace LiveMessenger
{
    public class CheckCookie
    {
        //Method return true if there is a username cookie present
        public static bool checkUsername(HttpRequest Request)
        {
            if (Request.Cookies["username"] != null) return true;
            return false;
        }
    }
}