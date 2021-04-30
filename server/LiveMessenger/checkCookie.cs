using System;
using System.Web;

namespace LiveMessenger
{
    public class checkCookie
    {
        public static bool checkUsername(HttpRequest Request)
        {
            if (Request.Cookies["username"] != null) return true;
            return false;
        }
    }
}