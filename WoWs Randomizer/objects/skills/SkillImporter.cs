﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WoWs_Randomizer.utils.skills
{
    [Serializable]
    class SkillImporter
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("meta")]
        public MetaData MetaInfo { get; set; }

        [JsonProperty("data")]
        public Dictionary<string, Skill> Data { get; set; }
    }
}
