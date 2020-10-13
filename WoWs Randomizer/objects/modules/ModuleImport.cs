﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WoWs_Randomizer.utils;

namespace WoWs_Randomizer.utils.module
{
    [Serializable]
    class ModuleImport
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("meta")]
        public MetaData MetaInfo { get; set; }

        [JsonProperty("data")]
        public Dictionary<string, ModuleData> Data { get; set; }
    }
}
