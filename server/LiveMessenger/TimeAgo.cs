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
    public class TimeAgo
    {
        public static string Calculate(DateTime date)
        {
            int SECOND = 1;
            int MINUTE = 60 * SECOND;
            int HOUR = 60 * MINUTE;
            int DAY = 24 * HOUR;
            int MONTH = 30 * DAY;

            TimeSpan timespan = new TimeSpan(DateTime.Now.Ticks - date.Ticks);
            double diffrence = Math.Abs(timespan.TotalSeconds);


            if (timespan.Seconds == 0) 
                return "Just now";

            if (diffrence < 1 * MINUTE)
                return timespan.Seconds == 1 ? "one second ago" : timespan.Seconds + " seconds ago";

            if (diffrence < 2 * MINUTE)
                return "a minute ago";

            if (diffrence < 45 * MINUTE)
                return timespan.Minutes + " minutes ago";

            if (diffrence < 90 * MINUTE)
                return "an hour ago";

            if (diffrence < 24 * HOUR)
                return timespan.Hours + " hours ago";

            return date.ToString();

        }


    }
}
