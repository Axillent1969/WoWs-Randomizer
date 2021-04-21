using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using WoWs_Randomizer.utils.modules;

namespace WoWs_Randomizer.utils.module
{
    [Serializable]
    class ModuleData
    {
        
        [JsonProperty("profile")]
        [field: NonSerialized] public Dictionary<string, Dictionary<string, object>> Profile { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("image")]
        public string ImageUrl { get; set; }
        [JsonProperty("tag")]
        public string Tag { get; set; }
        [JsonProperty("module_id_str")]
        public string IDString { get; set; }
        [JsonProperty("module_id")]
        public long ID { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("price_credit")]
        public long PriceCredits { get; set; }

        public double HullHealth { get; set; }
        public double AABarrels { get; set; }
        public double TorpedoBarrels { get; set; }
        public double PlanesAmount { get; set; }
        public double ArtilleryBarrels { get; set; }
        public double SecondaryBarrels { get; set; }

        public double EngineSpeed { get; set; }
        public ModuleArtillery Artillery { get; set; }

        public double FireDistance { get; set; }
        public double FireDistanceIncrease { get; set; }

        public double TorpedoSpeed { get; set; }
        public double TorpedoReload { get; set; }
        public double TorpedoRange { get; set; }
        public double TorpedoDamage { get; set; }
        public long FighterSquadrons { get; set; }
        public long BomberSquadrons { get; set; }
        public long TorpedoSquadrons { get; set; }

        public ModuleDiveBomber DiveBomber { get; set; }
        public ModuleTorpedoBomber TorpedoBomber { get; set; }

        public ModuleFighter Fighter { get; set; }

    }
}
