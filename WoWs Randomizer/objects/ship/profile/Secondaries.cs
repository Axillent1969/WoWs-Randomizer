using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WoWs_Randomizer.utils.ship.profile
{
    [Serializable]
    public class Secondaries
    {
        [JsonProperty("distance")]
        public double Distance { get; set; }
        [JsonProperty("slots")]
        public Dictionary<string,SecondariesData> Slots { get; set; }

    }
}
