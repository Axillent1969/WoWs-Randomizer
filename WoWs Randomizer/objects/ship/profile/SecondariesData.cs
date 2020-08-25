﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WoWs_Randomizer.objects.ship.profile
{
    [Serializable]
    public class SecondariesData
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("gun_rate")]
        public double RateOfFire { get; set; }

        [JsonProperty("burn_probability")]
        public double FireChance { get; set; }
        public double ReloadTime ()
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
