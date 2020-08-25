﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WoWs_Randomizer.objects.ship

{
    [Serializable]
    public class ShipImage
    {
        [JsonProperty("small")]
        public string Small { get; set; }
        [JsonProperty("large")]
        public string Large { get; set; }
        [JsonProperty("medium")]
        public string Medium { get; set; }
        [JsonProperty("countour")]
        public string Contour { get; set; }
    }
}
