using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoWs_Randomizer.utils.ship.profile
{
    [Serializable]
    public class Mobility
    {
        [JsonProperty("rudder_time")]
        public double RudderTime { get; set; }
        [JsonProperty("turning_radius")]
        public double TurningRadius { get; set; }
        [JsonProperty("max_speed")]
        public double MaxSpeed { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }
}
