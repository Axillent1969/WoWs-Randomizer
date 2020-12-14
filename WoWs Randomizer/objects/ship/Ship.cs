using System;
using System.Collections.Generic;
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

        public bool canEquipSmokeGeneratorMod1()
        {
            return (this.GetConsumableInfo(ConsumableType.Smoke) != null);
        }

        public bool canEquipSRM1()
        {
            return (this.GetConsumableInfo(ConsumableType.Radar) != null);
        }

        public bool canEquipHydroMod1()
        {
            return (this.GetConsumableInfo(ConsumableType.Hydro) != null);
        }

        public bool canEquipDefAAMod1()
        {
            return (this.GetConsumableInfo(ConsumableType.DefAA) != null);
        }

        public bool canEquipEngineBoostMod1()
        {
            return (this.GetConsumableInfo(ConsumableType.SpeedBoost) != null);

        }

        public bool canEquipEmergencyEnginePower()
        {
            return (this.GetConsumableInfo(ConsumableType.EmergencyEnginePower) != null);
        }

        public bool canEquipSpottingAircraftMod1()
        {
            return (this.GetConsumableInfo(ConsumableType.SpotterPlane) != null);
        }

        public void ApplyUpgradeCorrections()
        {
            HashSet<long> upgrades = new HashSet<long>(this.Upgrades);
            upgrades.Add(4253208496); // Damage Control Party Mod 1. All ships have it but not present in API data.

            // Slot 1
            upgrades.Add(4262645680); // Main Armaments Mod 1
            upgrades.Add(4261597104); // Auxilliary Mod 1
            upgrades.Add(4260548528); // Magazine Mod 1
            if (this.ID == 4267620048 || this.ID == 4290688720 || this.ID == 3767449296)
            {
                upgrades.Add(4258451376); // Aiming Systems Mod 0
            }

            if ( this.Tier >= 3 )
            {
                upgrades.Add(4273131440); // Damage Control Sys Mod 1
                upgrades.Add(4221751216); // Engine Room Protection
            }

            if ( this.Tier >= 5)
            {
                //upgrades.Add(4293054384); // Main Battery Mod 1
                if ( this.Country.ToString().ToLower().Equals(Countries.USA.ToString().ToLower()))
                {
                    upgrades.Add(4264742832); // Artillery Plotting Room Mod 1
                } else
                {
                    upgrades.Add(4259499952); // Aiming Systems Mod 1
                }

                if ( !IsCV() && HasTorpedoArmaments() )
                {
                    upgrades.Add(4220702640); // Torpedo Tubes Mod 1
                }
                if (!IsCV() )
                {
                    upgrades.Add(4289908656); // AA Guns Mod 1
                }
                upgrades.Add(4281520048); // Secondary Battery Mod 1
            }

            if ( this.Tier >= 6)
            {
                upgrades.Add(4269985712); // Damage Control System Mod 2
                upgrades.Add(4271034288); // Steering Gears Mod 1
                if ( !IsUKLightCruiser() && !IsUKDD() )
                {
                    upgrades.Add(4272082864); // Propulsion Mod 1
                }
            }

            if ( this.Tier >= 8)
            {
                upgrades.Add(4266839984); // Torpedo Lookup System
                if ( !IsCV() )
                {
                    upgrades.Add(4218605488); // Ship Consumables Modification
                    if ( !IsBB() )
                    {
                        upgrades.Add(4257402800); // Steering Gears Mod 2
                    }
                }
                upgrades.Add(4265791408); // Concealment System Mod 1
            }

            if ( this.Tier >= 9)
            {
                upgrades.Add(4287811504); // Main Battery Mod 2
                if ( HasTorpedoArmaments())
                {
                    upgrades.Add(4286762928); // Torpedo Tubes Mod 2
                }
                if (IsUSSRDD() || IsUSSRBB() )
                {
                    // Not allowed to use this upgrade...
                } else if ( IsUSBB() )
                {
                    // Can't use GFC Sys Mod 2 - Using Artillery Plotting Room Mod 2 instead.
                    upgrades.Add(4263694256);
                } else
                {
                    upgrades.Add(4278374320); // Gun Fire Control System Mod 2
                }
                upgrades.Add(4216508336); // Auxiliary Armaments Mod 2
            }

            if (IsCV())
            {
                upgrades.Add(4290957232); // Air Groups Mod 1
                if (this.Tier >= 3)
                {
                    upgrades.Add(4222799792); // Aircraft Engines Mod 1
                }
                if (this.Tier >= 5)
                {
                    upgrades.Add(4223848368); // Attack Aircraft Mod 1
                    upgrades.Add(4224896944); // Torpedo Bombers Mod 1
                    upgrades.Add(4219654064); // Aerial Torpedoes Mod 1
                }
                if ( this.Tier >= 8)
                {
                    upgrades.Add(4217556912); // Squadron Consumables Mod 1
                    upgrades.Add(0); // Flight Control Mod 1
                }
                if ( this.Tier >= 9 )
                {
                    upgrades.Add(4277325744); // Flight Control Mod 2
                    upgrades.Add(4283617200); // Air Groups Mod 2
                }
            }

            Dictionary<long, long> Legendary = new Dictionary<long, long>();
            Legendary = getLegendaryList();
            if (Legendary.ContainsKey(this.ID))
            {
                upgrades.Add(Legendary[this.ID]);
            }

            //Special upgrades
            if (this.canEquipSpottingAircraftMod1())
            {
                upgrades.Add(4254257072);
            }
            if (this.canEquipEngineBoostMod1())
            {
                upgrades.Add(4256354224);
            }
            if (this.canEquipDefAAMod1())
            {
                upgrades.Add(4252159920);
            }
            if (this.canEquipHydroMod1())
            {
                upgrades.Add(4251111344);
            }
            if (this.canEquipSRM1())
            {
                upgrades.Add(4250062768);
            }
            if (this.canEquipSmokeGeneratorMod1())
            {
                upgrades.Add(4255305648);
            }

            this.Upgrades = new long[upgrades.Count];
            upgrades.CopyTo(this.Upgrades);
        }

        private Dictionary<long, long> getLegendaryList()
        {
            Dictionary<long, long> Legendary = new Dictionary<long, long>();

            Legendary.Add(4277090288, 4244819888); // Montana
            Legendary.Add(4179572688, 4179572688); // Conq.
            Legendary.Add(4179539760, 4249014192); // Hindenburg
            Legendary.Add(4179539792, 4241674160); // Henry IV
            Legendary.Add(4179539920, 4240625584); // Minotaur
            Legendary.Add(4179506640, 4236431280); // Khabarovsk
            Legendary.Add(4179506992, 4235382704); // Z-52
            Legendary.Add(4281219056, 4233285552); // Gearing
            Legendary.Add(4179506384, 4232236976); // Yueyang
            Legendary.Add(4179507152, 4215459760); // Daring
            Legendary.Add(4074649296, 4213362608); // Harugumo

            Legendary.Add(4179572560, 4247965616); // Republique
            Legendary.Add(4179572528, 4246917040); // Großer Kurfürst
            Legendary.Add(4276041424, 4245868464); // Yamato
            Legendary.Add(4259231440, 4243771312); // Zao
            Legendary.Add(4273911792, 4239577008); // Des Moines
            Legendary.Add(4074682352, 4238528432); // Worcester
            Legendary.Add(4179539408, 4237479856); // Moskva
            Legendary.Add(4282267344, 4234334128); // Shimakaze
            Legendary.Add(4074649040, 4231188400); // Grozovoi
            Legendary.Add(4179507024, 4214411184); // Kleber
            Legendary.Add(4179572176, 4212314032); // Kremlin
            Legendary.Add(4179605488, 4230139824); // Midway
            Legendary.Add(4179605200, 4229091248); // Hakuryu
            Legendary.Add(4074747856, 4211265456); // Audacious

            return Legendary;
        }

        private bool IsUSBB()
        {
            bool isUS = this.Country.ToLower().Equals(Countries.USA.ToString().ToLower());
            return isUS && IsBB();
        }

        private bool IsUSSRBB()
        {
            bool isUSSR = this.Country.ToLower().Equals(Countries.USSR.ToString().ToLower());
            return isUSSR && IsBB();
        }

        private bool IsUSSRDD()
        {
            bool isUSSR = this.Country.ToLower().Equals(Countries.USSR.ToString().ToLower());
            return isUSSR && IsDD();
        }

        private bool IsBB()
        {
            return this.ShipType.ToLower().Equals(ShipTypes.BB.ToString().ToLower());
        }

        private bool IsDD()
        {
            return this.ShipType.ToString().ToString().ToLower().Equals(ShipTypes.DD.ToString().ToLower());
        }

        private bool IsUKDD()
        {
            bool isUK = this.Country.ToLower().Equals(Countries.UK.ToString().ToLower());
            return isUK && IsDD();
        }

        private bool IsUKLightCruiser()
        {
            // Plymouth, Mino, Neptune, Belfast'43, Edinburgh, Belfast, Fiji, Leander
            List<long> cl = new List<long>();
            cl.Add(3760109520);
            cl.Add(4179539920);
            cl.Add(4180588496);
            cl.Add(3741235152);
            cl.Add(4181637072);
            cl.Add(3763255248);
            cl.Add(4182685648);
            cl.Add(4183734224);
            return cl.Contains(this.ID);
        }

        private bool IsCV()
        {
            return this.ShipType.ToLower().Equals(ShipTypes.CV.ToString().ToLower());
        }

        private bool HasTorpedoArmaments()
        {
            return this.Modules.Torpedoes != null && this.Modules.Torpedoes.Length > 0;
        }
    }
}
