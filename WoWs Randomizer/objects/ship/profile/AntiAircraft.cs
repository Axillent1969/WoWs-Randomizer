using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoWs_Randomizer.objects.ship.profile
{
    public class AntiAircraft
    {
        [JsonProperty("slots")]
        public Dictionary<string,AntiAircraftMount> AAMounts { get; set; }

        override public string ToString()
        {
            if ( AAMounts == null ) { return ""; }
            string ret = "";
            foreach(KeyValuePair<string,AntiAircraftMount> entry in AAMounts)
            {
                AntiAircraftMount mount = entry.Value;
                ret += mount.Guns + "x" + mount.Caliber + "/" + mount.Damage + ", ";
            }
            if ( ret.EndsWith(", "))
            {
                ret = ret.Substring(0, ret.Length - 2);
            }
            return ret;
        }
    }
}
