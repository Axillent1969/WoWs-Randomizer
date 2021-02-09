using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoWs_Randomizer.objects.player
{
    [Serializable]
    class PlayerPVPStatistics
    {
        [JsonProperty("max_xp")]
        public long MaxXP { get; set; }
        [JsonProperty("max_damage_scouting")]
        public long MaxScoutingDamage { get; set; }
        [JsonProperty("ships_spotted")]
        public long ShipsSpotted { get; set; }

        [JsonProperty("xp")]
        public long Experience { get; set; }
        [JsonProperty("survived_battles")]
        public long SurvivedBattles { get; set; }
        [JsonProperty("dropped_capture_points")]
        public long DroppedCapturePoints { get; set; }
        [JsonProperty("draws")]
        public long Draws { get; set; }
        [JsonProperty("control_capture_points")]
        public long ControlCapturePoints { get; set; }
        [JsonProperty("battles_since_510")]
        public long BattlesSince510 { get; set; }
        [JsonProperty("planes_killed")]
        public long PlanesKilled { get; set; }
        [JsonProperty("battles")]
        public long Battles { get; set; }
        [JsonProperty("max_ships_spotted")]
        public long MaxShipsSpotted { get; set; }
        [JsonProperty("survived_wins")]
        public long SurvivedBattlesWin { get; set; }
        [JsonProperty("frags")]
        public long ShipsKilled { get; set; }

        [JsonProperty("damage_scouting")]
        public long ScoutingDamage { get; set; }
        [JsonProperty("max_frags_battle")]
        public long ShipsKilledBattle { get; set; }
        [JsonProperty("capture_points")]
        public long CapturePoints { get; set; }
        [JsonProperty("max_damage_dealt")]
        public long MaxDamageDealt { get; set; }
        [JsonProperty("max_damage_dealt_ship_id")]
        public long MaxDamageDealtShipId { get; set; }
        [JsonProperty("wins")]
        public long Wins { get; set; }
        [JsonProperty("losses")]
        public long Losses { get; set; }
        [JsonProperty("max_planes_killed")]
        public long MaxPlanesKilled { get; set; }

        [JsonProperty("max_planes_killed_ship_id")]
        public long MaxPlanesKilledShipId { get; set; }

        [JsonProperty("damage_dealt")]
        public long DamageDealt { get; set; }

        ///TODO: Add main_battery, second_battery, torpedoes, aircraft, ramming : These requires objects to be created

    }
}
