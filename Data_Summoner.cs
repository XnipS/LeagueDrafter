using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueDrafter
{
    public class Data_Summoner
    {
        public Summoner Summoner { get; set; }
    }

    public class Summoner
    {
        public string accountId { get; set; }
        public string name { get; set; }
        public long summonerLevel { get; set; }
        public string puuid { get; set; }
        public string id { get; set; }

        public long revisionDate { get; set; }
    }
}
