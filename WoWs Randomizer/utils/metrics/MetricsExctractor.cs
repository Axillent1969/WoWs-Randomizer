using System;
using System.Collections.Generic;
using System.Linq;
using WoWs_Randomizer.utils.module;
using WoWs_Randomizer.utils.ship;
using WoWs_Randomizer.utils.ship.profile;
using WoWs_Randomizer.utils.metrics;

namespace WoWs_Randomizer.utils
{
    class MetricsExctractor
    {
        private Ship RandomizedShip = null;
        private readonly Dictionary<string, ModuleData> AllModules = null;
        private ShipMetrics Metrics = new ShipMetrics();
        private Dictionary<string, Module> Modules = null;

        public MetricsExctractor(Ship ship)
        {
            RandomizedShip = ship;
            Modules = RandomizedShip.ModuleTree;
            AllModules = Program.AllModules;
            CalculateMetrics();
        }

        public void ChangeShip(Ship ship)
        {
            RandomizedShip = ship;
            Modules = RandomizedShip.ModuleTree;
            Metrics = new ShipMetrics();
            CalculateMetrics();
        }

        public ShipMetrics GetMetrics()
        {
            return Metrics;
        }

        private void CalculateMetrics()
        {
            CalculateMainData();
            CalculateEngineData();
            CalculateMobility();
            CalculateHull();
            CalculateTorp();
            CalculateFlightControl();
            CalculateArtillery();
            CalculateSecondaries();
            CalculateFireChanceMain();
            CalculateConcealment();
            CalculateFireControl();
            CalculateAntiAircraft();
        }

        private void CalculateMainData()
        {
            Metrics.isPremium = RandomizedShip.Premium;
            Metrics.ShipClass = RandomizedShip.ShipType;
            Metrics.Tier = RandomizedShip.Tier;

        }
        private void CalculateSecondaries()
        {
            Secondaries sec = RandomizedShip.Profile.Secondaries;
            
            if (sec != null && sec.Slots != null)
            {
                Metrics.Secondaries = sec.Slots;
                Metrics.SecondaryRange = sec.Distance;
            }
        }

        private void CalculateEngineData()
        {
            long[] availableModules = RandomizedShip.Modules.Engine;
            ModuleData MData = GetModuleData(availableModules);

            Metrics.Engine = MData.Name;
            if (MData.EngineSpeed != 0)
            {
                Metrics.Speed = MData.EngineSpeed;
            }
            else
            {
                Metrics.Speed = (double)MData.Profile["engine"]["max_speed"];
            }
        }

        private void CalculateHull()
        {
            long CurrentModuleID = 0;
            ModuleData MData = null;
            try
            {
                long[] availableModules = RandomizedShip.Modules.Hull;
                CurrentModuleID = availableModules[0];
                MData = GetModuleData(availableModules);
                double hp = 0;
                if (MData.HullHealth != 0)
                {
                    hp = MData.HullHealth;
                }
                else
                {
                    hp = Double.Parse(MData.Profile["hull"]["health"].ToString());
                }
                Metrics.HP = hp;
            }
            catch (Exception)
            {
                if (MData != null)
                {
                    foreach (KeyValuePair<string, Dictionary<string, object>> Prof in MData.Profile)
                    {
                        foreach (KeyValuePair<string, object> Hull in Prof.Value)
                        {
                            Console.WriteLine(Hull.Key + " = " + Hull.Value);
                        }
                    }
                }
            }
        }

        private void CalculateMobility()
        {
            try
            {
                if ( RandomizedShip.Profile.Mobility != null)
                {
                    Metrics.RudderTime = RandomizedShip.Profile.Mobility.RudderTime;
                    Metrics.TurningRadius = RandomizedShip.Profile.Mobility.TurningRadius;
                }
            } catch (Exception) { }
        }

        private void CalculateTorp()
        {
            if (RandomizedShip.Modules.Torpedoes != null)
            {
                long[] availableModules = RandomizedShip.Modules.Torpedoes;

                if (availableModules.Length > 0)
                {
                    ModuleData MData = GetModuleData(availableModules);

                    TorpedoExtractor torpExtract = new TorpedoExtractor(MData);
                    Metrics.TorpedoReload = torpExtract.ReloadTime;
                    Metrics.TorpedoDamage = torpExtract.Damage;
                    Metrics.TorpedoDistance = torpExtract.Distance;
                    Metrics.TorpedoSpeed = torpExtract.TravelSpeed;
                }
            }
        }

        private void CalculateFlightControl()
        {
            if (RandomizedShip.Modules.FlightControl != null)
            {
                long[] availableModules = RandomizedShip.Modules.FlightControl;
                if (availableModules.Length > 0)
                {
                    ModuleData MData = GetModuleData(availableModules);

                    long Fsquadrons = 0;
                    long Bsquadrons = 0;
                    long Tsquadrons = 0;

                    if (MData.FighterSquadrons != 0)
                    {
                        Fsquadrons = MData.FighterSquadrons;
                        Bsquadrons = MData.BomberSquadrons;
                        Tsquadrons = MData.TorpedoSquadrons;
                    }
                    else
                    {
                        if (MData.Profile != null && MData.Profile["flight_control"] != null && MData.Profile["flight_control"]["fighter_squadrons"] != null )
                        {
                            Fsquadrons = long.Parse(MData.Profile["flight_control"]["fighter_squadrons"].ToString());
                            Bsquadrons = long.Parse(MData.Profile["flight_control"]["bomber_squadrons"].ToString());
                            Tsquadrons = long.Parse(MData.Profile["flight_control"]["torpedo_squadrons"].ToString());
                        } 
                    }

                    Metrics.FighterSquadrons = Fsquadrons;
                    Metrics.BomberSquadrons = Bsquadrons;
                    Metrics.TorpedoSquadrons = Tsquadrons;
                }
            }
        }

        private void CalculateArtillery()
        {
            if (RandomizedShip.Modules.Artillery != null)
            {
                long[] availableModules = RandomizedShip.Modules.Artillery;
                if (availableModules.Length > 0)
                {
                    ModuleData MData = GetModuleData(availableModules);

                    ArtilleryExtractor artilleryExtractor = new ArtilleryExtractor(MData, RandomizedShip);

                    Metrics.MainCaliber = artilleryExtractor.GunCaliber();
                    Metrics.Dispersion = artilleryExtractor.Dispersion();
                    Metrics.MainCaliberName = MData.Name;
                    Metrics.RotationTime = artilleryExtractor.RotationTime();
                    Metrics.FireRateMain = artilleryExtractor.FireRate();
                    Metrics.APDamage = artilleryExtractor.APDamage();
                    Metrics.HEDamage = artilleryExtractor.HEDamage();

                }
            }
        }

        private void CalculateFireChanceMain()
        {
            if (RandomizedShip.Profile.Artillery != null && RandomizedShip.Profile.Artillery.Shells.ContainsKey("HE"))
            {
                Metrics.FireChanceMain = (double)RandomizedShip.Profile.Artillery.Shells["HE"].FireChance;
            }
        }

        private void CalculateConcealment()
        {
            if ( RandomizedShip.Profile.Concealment != null )
            {
                Metrics.AirDetection = RandomizedShip.Profile.Concealment.AirDetection;
                Metrics.SurfaceDetection = RandomizedShip.Profile.Concealment.SurfaceDetection;
            }
        }

        private void CalculateFireControl()
        {
            if (RandomizedShip.Modules.FireControl != null)
            {
                long[] availableModules = RandomizedShip.Modules.FireControl;
                if (availableModules.Length > 0)
                {
                    ModuleData MData = GetModuleData(availableModules);

                    double distance = 0;
                    double distanceIncrease = 0;

                    if (MData.FireDistance != 0)
                    {
                        distance = MData.FireDistance;
                        distanceIncrease = MData.FireDistanceIncrease;
                    }
                    else
                    {
                        distance = double.Parse(MData.Profile["fire_control"]["distance"].ToString());
                        distanceIncrease = double.Parse(MData.Profile["fire_control"]["distance_increase"].ToString());
                    }

                    Metrics.Distance = distance;
                    Metrics.DistanceIncrease = distanceIncrease;
                }
            }
        }

        private ModuleData GetModuleData(long[] ModuleID)
        {
            ModuleData MData = null;
            bool valueExists = true;

            foreach(long ID in ModuleID)
            {
                // Correction to use Shima's 12km torps instead of the 8km
                if (ID == 3346411216)
                {
                    Module ThisModule = Modules[ID.ToString()];
                    MData = AllModules[ThisModule.ID.ToString()];
                    return MData;
                }
            }

            foreach (long CurrentModuleID in ModuleID)
            {
                Module ThisModule = Modules[CurrentModuleID.ToString()];
                
                if (ThisModule.NextModules != null)
                {
                    long nextModule = ThisModule.NextModules[0];
                    if (ModuleID.Contains(nextModule))
                    {
                        valueExists = true;

                    }
                    else
                    {
                        valueExists = false;
                        MData = AllModules[ThisModule.ID.ToString()];
                    }
                }
                else
                {
                    valueExists = false;
                    MData = AllModules[ThisModule.ID.ToString()];
                }
                if (valueExists == false)
                {
                    break;
                }
            }
            return MData;
        }

        private void CalculateAntiAircraft()
        {
            Metrics.AntiAircraft = RandomizedShip.Profile.AntiAircraft;
        }
    }
}
