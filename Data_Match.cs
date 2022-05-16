using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueDrafter
{
    public class Data_Match
    {
        public Info info { get; set; }
        
    }
    public class Info
    {
        public List<Participant> participants { get; set; }
    }
    public class Participant
    {
        public bool win { get; set; }
        public string puuid { get; set; }
    }

}
