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
            date = date.ToLocalTime();
            DateTime currentTime = DateTime.Now;
            int second = 1;
            int minute = 60 * second;
            int hour = 60 * minute;

            TimeSpan timespan = new TimeSpan(currentTime.Ticks - date.Ticks);
            double diffrence = Math.Abs(timespan.TotalSeconds);


            if (timespan.Seconds == 0) 
                return "Just now";

            if (diffrence < 1 * minute)
                return timespan.Seconds == 1 ? "one second ago" : timespan.Seconds + " seconds ago";

            if (diffrence < 2 * minute)
                return "a minute ago";

            if (diffrence < 45 * minute)
                return timespan.Minutes + " minutes ago";

            if (diffrence < 90 * minute)
                return "an hour ago";

            if (diffrence < 24 * hour)
                return timespan.Hours + " hours ago";

            return date.ToString();

        }


    }
}
