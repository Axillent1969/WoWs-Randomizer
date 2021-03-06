﻿using System;
using Newtonsoft.Json;

namespace WoWs_Randomizer.utils.ship.profile

{
    [Serializable]
    public class Engine
    {
        [JsonProperty("engine_id_str")]
        public string EngineID { get; set; }
        [JsonProperty("max_speed")]
        public double Speed { get; set; }
        [JsonProperty("engine_id")]
        public string ID { get; set; }
    }
}
