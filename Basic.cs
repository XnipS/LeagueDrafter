using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueDrafter
{
    internal static class Basic
    {
        public static DateTime UnixToDateTime(long unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddMilliseconds(unixTimeStamp);
            return dateTime;
        }
        //DDragon Game Version
        internal static async Task<string> GetCurrentGameVersionAsync()
        {
            using var client = new HttpClient();
            string x = await client.GetStringAsync("https://ddragon.leagueoflegends.com/api/versions.json");
            x = x.Replace("[", "");
            x = x.Replace("]", "");
            x = x.Replace("\"", "");
            var y = x.Split(",");
            return y[0];
        }
        //Clean file path regardless of user
        internal static string GetKeyPath()
        {
            var x = AppContext.BaseDirectory;
            x = FlipString(x);
            x = x.Remove(1, 25);
            x = FlipString(x);
            return x;
        }
        //Flip string
        internal static string FlipString(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        //Relative time
        internal static string RelativeTime (DateTime date)
        {
            var timePassed = new TimeSpan(DateTime.UtcNow.Ticks - date.Ticks);
            double deltaTime = Math.Abs(timePassed.TotalSeconds);
            if(deltaTime < 45 * 60)
            {
                //minutes ago
                return timePassed.Seconds + " seconds ago.";
            }
            if(deltaTime < 90 * 60 * 60)
            {
                //hours ago
                return timePassed.Hours + " hours ago.";
            }
            if(deltaTime < 30 * 24 * 60 * 60)
            {
                //days ago
                return timePassed.Days + " days ago.";
            }
            if(deltaTime < 12 * 30 * 24 * 60 * 60)
            {
                //months ago
                int months = Convert.ToInt32(Math.Floor((double)timePassed.Days / 30));
                return months + " months ago.";
            }
            return "Over a year ago.";
        }
    }
}
