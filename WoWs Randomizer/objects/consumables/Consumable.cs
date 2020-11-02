using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WoWs_Randomizer.objects.consumables
{
    [Serializable]
    public class Consumable : IEquatable<Consumable>, IComparable<Consumable>
    {

        [JsonProperty("profile")]
        public Dictionary<string, ConsumableProfile> Profile { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("price_gold")]
        public long Gold { get; set; }
        [JsonProperty("image")]
        public string ImageUrl { get; set; }
        [JsonProperty("consumable_id")]
        public long ID { get; set; }
        [JsonProperty("price_credit")]
        public long Credits { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }

        public int CompareTo(Consumable other)
        {
            if (other == null) { return 0; }
            string otherCompare = other.GetSlotNumber() + "-" + other.Name;
            string thisCompare = this.GetSlotNumber() + "-" + this.Name;
            return thisCompare.CompareTo(otherCompare);
        }

        public override int GetHashCode()
        {
            return Convert.ToInt32(ID);
        }

        public bool Equals(Consumable other)
        {
            if (other == null) return false;
            return (this.ID.Equals(other.ID));
        }

        public int GetSlotNumber()
        {
            if ( this.Type.Equals("Modernization"))
            {

                if (this.Credits == 250000)
                {
                    return 2;
                }
                else if (this.Credits == 500000)
                {
                    return 3;
                }
                else if (this.Credits == 1000000)
                {
                    return 4;
                }
                else if (this.Credits == 2000000)
                {
                    return 5;
                } else if ( this.Credits == 5000000 )
                {
                    List<long> slot5Consumables = new List<long>() { 4244819888, 4179572688, 4249014192, 4241674160, 4240625584, 4236431280, 4235382704, 4233285552, 4232236976, 4215459760, 4213362608 };
                    if ( slot5Consumables.Contains(this.ID))
                    {
                        return 5;
                    } else
                    {
                        return 6;
                    }
                }
                else if (this.Credits == 3000000)
                {
                    return 6;
                } else
                {
                    return 1;
                }
            }
            return 0;
        }

    }
}
