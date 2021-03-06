﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using WoWs_Randomizer.objects.ship.profile;

namespace WoWs_Randomizer.utils.ship.profile
{
    [Serializable]
    public class Artillery
    {
        [JsonProperty("distance")]
        public double Distance { get; set; }
        [JsonProperty("artillery_id")]
        public long ID { get; set; }

        [JsonProperty("artillery_id_str")]
        public string IDString { get; set; }
        [JsonProperty("max_dispersion")]
        public double Dispersion { get;set; }

        [JsonProperty("rotation_time")]
        public double RotationTime { get; set; }

        [JsonProperty("shells")]
        public Dictionary<string,Shells> Shells { get; set; }

        [JsonProperty("gun_rate")]
        public double RateOfFire { get; set; }
        [JsonProperty("slots")]
        public Dictionary<string,ArtillerySlot> Slots { get; set; }
        public double ReloadTime()
        {
            if ( RateOfFire != 0 )
            {
                double reload = 60 / RateOfFire;
                return Math.Round(reload, 1);
            } else
            {
                return 0;
            }
        }
    }
}
