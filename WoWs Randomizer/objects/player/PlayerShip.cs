using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WoWs_Randomizer.objects.player

{
    [Serializable]
    class PlayerShip
    {
        [JsonProperty("ship_id")]
        public long ID { get; set; }
    }
}
