using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WoWs_Randomizer.objects.ship
{
    [Serializable]
    public class ShipModule
    {
        [JsonProperty("engine")]
        public long[] Engine { get; set; }
        [JsonProperty("torpedo_bomber")]
        public long[] TorpedoBomber { get; set; }
        [JsonProperty("fighter")]
        public long[] Fighter { get; set; }
        [JsonProperty("hull")]
        public long[] Hull { get; set; }
        [JsonProperty("artillery")]
        public long[] Artillery { get; set; }
        [JsonProperty("torpedoes")]
        public long[] Torpedoes { get; set; }
        [JsonProperty("fire_Control")]
        public long[] FireControl { get; set; }
        [JsonProperty("flight_control")]
        public long[] FlightControl { get; set; }
        [JsonProperty("dive_bomber")]
        public long[] DiveBomber { get; set; }
    }
}
