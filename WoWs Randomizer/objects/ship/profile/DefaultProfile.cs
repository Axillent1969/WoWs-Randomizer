﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WoWs_Randomizer.objects.ship.profile
{
    [Serializable]
    public class DefaultProfile
    {
        [JsonProperty("engine")]
        public Engine Engine { get; set; }
        [JsonProperty("atbas")]
        public Secondaries Secondaries { get; set; }

        [JsonProperty("artillery")]
        public Artillery Artillery { get; set; }

        [JsonProperty("concealment")]
        public Concealment Concealment { get; set; }
    }
}
