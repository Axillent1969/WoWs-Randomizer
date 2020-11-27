using System;
using System.Collections.Generic;
using Newtonsoft.Json;

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
