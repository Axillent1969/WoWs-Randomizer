using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WoWs_Randomizer.objects.ship.profile;

namespace WoWs_Randomizer.objects.ship
{
    [Serializable]
    public class Ship : IEquatable<Ship>
    {
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("price_gold")]
        public long PriceGold { get; set; }
        [JsonProperty("ship_id_str")]
        public string ShipId { get; set; }
        [JsonProperty("has_demo_profile")]
        public bool DemoProfile { get; set; }
        [JsonProperty("images")]
        public ShipImage Images { get; set; }
        [JsonProperty("modules")]
        public ShipModule Modules { get; set; }

        [JsonProperty("modules_tree")]
        public Dictionary<string,Module> ModuleTree { get; set; }

        [JsonProperty("nation")]
        public string Country { get; set; }
        [JsonProperty("is_premium")]
        public bool Premium { get; set; }
        [JsonProperty("ship_id")]
        public long ID { get; set; }
        [JsonProperty("price_credit")]
        public long PriceCredits { get; set; }

        [JsonProperty("default_profile")]
        public DefaultProfile Profile { get; set; }

        [JsonProperty("upgrades")]
        public long[] Upgrades { get; set; }
        [JsonProperty("tier")]
        public int Tier { get; set; }

        [JsonProperty("mod_slots")]
        public int NumberOfSlots { get; set; }
        [JsonProperty("type")]
        public string ShipType { get; set; }
        [JsonProperty("is_special")]
        public bool Special { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }

        public bool Equals(Ship other)
        {
            if (other == null) return false;
            return (this.ID.Equals(other.ID));
        }

        public override int GetHashCode()
        {
            return Convert.ToInt32(ID);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0019:Use pattern matching", Justification = "<Pending>")]
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Ship otherShip = obj as Ship;
            if (otherShip == null) return false;
            return Equals(otherShip);
        }
    }
}
