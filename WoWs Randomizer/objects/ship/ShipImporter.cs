﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WoWs_Randomizer.objects.ship
{
    [Serializable]
    class ShipImporter
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("meta")]
        public MetaData MetaInfo { get; set; }

        [JsonProperty("data")]
        public Dictionary<string, Ship> ShipData { get; set; }
    }
}
