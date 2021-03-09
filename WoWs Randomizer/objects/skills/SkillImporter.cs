using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WoWs_Randomizer.utils.skills
{
    [Serializable]
    class SkillImporter
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("skills")]
        public Dictionary<string, List<Skill>> Data { get; set; }
    }
}
