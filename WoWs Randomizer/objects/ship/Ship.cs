using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WoWs_Randomizer.objects.consumables;
using WoWs_Randomizer.utils.ship.profile;
using static WoWs_Randomizer.utils.ConsumableTypes;

namespace WoWs_Randomizer.utils.ship
{
    [Serializable]
    public class Ship : IEquatable<Ship>, IComparable<Ship>
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

        public List<ConsumableInfo> Consumables { get; set; }

        public ConsumableInfo GetConsumableInfo(ConsumableType CType)
        {
            ConsumableInfo info = null;
            if (this.Consumables != null)
            {
                info = this.Consumables.Find(c => c.Type == CType);
                return info;
            }
            return info;
        }

        public bool Equals(Ship other)
        {
            if (other == null) return false;
            return (this.ID.Equals(other.ID));
        }

        public override int GetHashCode()
        {
            return Convert.ToInt32(ID);
        }

        public override bool Equals(object obj)
        {
            if ( obj is Ship)
            {
                Ship otherShip = obj as Ship;
                return Equals(otherShip);
            } else
            {
                return false;
            }
        }

        public int CompareTo(Ship obj)
        {
            if ( obj == null ) { return 0; }
            return this.Name.CompareTo(obj.Name);
        }
    }
}
