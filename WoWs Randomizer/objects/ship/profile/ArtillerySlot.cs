using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WoWs_Randomizer.objects.ship.profile
{
    [Serializable]
    public class ArtillerySlot
    {
        [JsonProperty("barrels")]
        public int NumberOfBarrels { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("guns")]
        public int NumberOfGuns { get; set; }
    }
}
