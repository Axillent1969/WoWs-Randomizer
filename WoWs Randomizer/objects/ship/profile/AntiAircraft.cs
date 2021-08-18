using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoWs_Randomizer.objects.ship.profile
{
    public class AntiAircraft
    {
        [JsonProperty("slots")]
        public Dictionary<string,AntiAircraftMount> AAMounts { get; set; }
    }
}
