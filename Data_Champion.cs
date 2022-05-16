using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueDrafter
{
    public class Data_Champion
    {
        public Dictionary<string, Champion> Data { get; set; }
    }

    public class Champion
    {
        public string id { get; set; }
        public string key { get; set; }
        public string name { get; set; }
        public string title { get; set; }
    }
}
