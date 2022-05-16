using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueDrafter
{
    internal static class RAPI
    {
        public static async Task<Summoner> GetSummonerByNameAsync (string devkey, string region, string name)
        {
            using var client = new HttpClient();
            string x = await client.GetStringAsync("https://" + region + ".api.riotgames.com/lol/summoner/v4/summoners/by-name/" + name + "?api_key=" + devkey);

            var list = JsonConvert.DeserializeObject<Summoner>(x);
            return list;
        }

        public static async Task<List<Mastery>> GetMasteryByID(string devkey, string region, string id)
        {
            using var client = new HttpClient();
            string x = await client.GetStringAsync("https://" + region + ".api.riotgames.com/lol/champion-mastery/v4/champion-masteries/by-summoner/" + id + "?api_key=" + devkey);

            var list = JsonConvert.DeserializeObject<List<Mastery>>(x);
            return list;
        }
    }
}
