using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueDrafter
{
    internal static class Basic
    {
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
    }
}
