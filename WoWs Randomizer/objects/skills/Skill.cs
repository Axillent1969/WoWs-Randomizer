using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WoWs_Randomizer.utils.skills
{
    [Serializable]
    class Skill : IComparable<Skill>, IComparer<Skill>
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("points")]
        public int Tier { get; set; }
        [JsonProperty("icon")]
        public string ImageUrl { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("effect")]
        public string Effect { get; set; }
        [JsonProperty("notes")]
        public string Notes { get; set; }
        [JsonProperty("perks")]
        public List<Perk> Perks { get; set; }

        [JsonProperty("sort")]
        public int SortBy { get; set; }

        public int Compare(Skill x, Skill y)
        {
            if ( x.SortBy > y.SortBy )
            {
                return 1;
            } else if ( x.SortBy < y.SortBy )
            {
                return -1;
            }
            return 0;
        }

        public int CompareTo(Skill other)
        {
            return this.Compare(this, other);
        }
    }
}
