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
                int corr = GetSlotCorrectionNumber();
                if ( corr != 0)
                {
                    return corr;
                }
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
        private Dictionary<int, List<long>> GetSlotCorrections()
        {
            // Slot corrections: Upgrades that have a price that does not correspond with the default price for the upgrades in the same slot.
            // For instance: 
            Dictionary<int, List<long>> SlotCorrections = new Dictionary<int, List<long>>();
            List<long> Slot1Upgrades = new List<long>();
            Slot1Upgrades.Add(4253208496);
            Slot1Upgrades.Add(4254257072);

            List<long> Slot2Upgrades = new List<long>();
            Slot2Upgrades.Add(4221751216);
            Slot2Upgrades.Add(4256354224);
            Slot2Upgrades.Add(4252159920);
            Slot2Upgrades.Add(4251111344);
            Slot2Upgrades.Add(4250062768);

            List<long> Slot3Upgrades = new List<long>();
            Slot3Upgrades.Add(4255305648);

            List<long> Slot5Upgrades = new List<long>();
            Slot5Upgrades.Add(4218605488);
            Slot5Upgrades.Add(4241674160);
            Slot5Upgrades.Add(4233285552);
            Slot5Upgrades.Add(4249014192);
            Slot5Upgrades.Add(4240625584);
            Slot5Upgrades.Add(4236431280);
            Slot5Upgrades.Add(4232236976);
            Slot5Upgrades.Add(4244819888);
            Slot5Upgrades.Add(4179572688);
            Slot5Upgrades.Add(4235382704);
            Slot5Upgrades.Add(4215459760);
            Slot5Upgrades.Add(4213362608);

            List<long> Slot6Upgrades = new List<long>();
            Slot6Upgrades.Add(4216508336);
            Slot6Upgrades.Add(4237479856);
            Slot6Upgrades.Add(4234334128);
            Slot6Upgrades.Add(4245868464);
            Slot6Upgrades.Add(4247965616);
            Slot6Upgrades.Add(4246917040);
            Slot6Upgrades.Add(4243771312);
            Slot6Upgrades.Add(4239577008);
            Slot6Upgrades.Add(4231188400);
            Slot6Upgrades.Add(4230139824);
            Slot6Upgrades.Add(4229091248);
            Slot6Upgrades.Add(4238528432);
            Slot6Upgrades.Add(4214411184);
            Slot6Upgrades.Add(4212314032);
            Slot6Upgrades.Add(4211265456);

            SlotCorrections.Add(1, Slot1Upgrades);
            SlotCorrections.Add(2, Slot2Upgrades);
            SlotCorrections.Add(3, Slot3Upgrades);
            SlotCorrections.Add(5, Slot5Upgrades);
            SlotCorrections.Add(6, Slot6Upgrades);

            return SlotCorrections;
        }

        private int GetSlotCorrectionNumber()
        {
            Dictionary<int, List<long>> corrections = GetSlotCorrections();
            for(int i = 1; i <= 6; i++)
            {
                if ( corrections.ContainsKey(i) && corrections[i].Contains(this.ID))
                {
                    return i;
                }
            }
            return 0;
        }
    }
}
