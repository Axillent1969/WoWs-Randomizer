﻿using System;
using System.Collections.Generic;
using System.Linq;
using WoWs_Randomizer.objects;
using WoWs_Randomizer.objects.module;
using WoWs_Randomizer.objects.ship;
using WoWs_Randomizer.objects.ship.profile;
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
            CalculateHull();
            CalculateTorp();
            CalculateFlightControl();
            CalculateArtillery();
            CalculateSecondaries();
            CalculateFireChanceMain();
            CalculateConcealment();
            CalculateFireControl();
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
            catch (Exception e)
            {
                //Console.WriteLine(RandomizedShip.ID);
                //Console.WriteLine(e.Message);
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
                        Fsquadrons = long.Parse(MData.Profile["flight_control"]["fighter_squadrons"].ToString());
                        Bsquadrons = long.Parse(MData.Profile["flight_control"]["bomber_squadrons"].ToString());
                        Tsquadrons = long.Parse(MData.Profile["flight_control"]["torpedo_squadrons"].ToString());
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

                    double rotationTime = 0;
                    double fireRate = 0;
                    long apDamage = 0;
                    long heDamage = 0;

                    rotationTime = artilleryExtractor.RotationTime();
                    fireRate = artilleryExtractor.FireRate();
                    apDamage = artilleryExtractor.APDamage();
                    heDamage = artilleryExtractor.HEDamage();
                    /*
                    if (MData.Artillery != null)
                    {
                        rotationTime = MData.Artillery.RotationTime;
                        fireRate = MData.Artillery.GunRate;
                        apDamage = MData.Artillery.APDamage;
                        heDamage = MData.Artillery.HEDamage;
                    }
                    else
                    {
                        rotationTime = double.Parse(MData.Profile["artillery"]["rotation_time"].ToString());
                        fireRate = double.Parse(MData.Profile["artillery"]["gun_rate"].ToString());
                        if (MData.Profile["artillery"]["max_damage_AP"] != null)
                        {
                            apDamage = long.Parse(MData.Profile["artillery"]["max_damage_AP"].ToString());
                        }
                        if (MData.Profile["artillery"]["max_damage_HE"] != null)
                        {
                            heDamage = long.Parse(MData.Profile["artillery"]["max_damage_HE"].ToString());
                        }
                    }
                    string name = MData.Name;
                    if (name.Contains(" mm/") || name.Contains(" mm "))
                    {
                        string caliber = name.Substring(0, name.IndexOf(" "));
                        long guncaliber = long.Parse(caliber);
                        Metrics.MainCaliber = guncaliber;
                    }
                    if (RandomizedShip.Profile.Artillery != null && RandomizedShip.Profile.Artillery.Dispersion != 0)
                    {
                        Metrics.Dispersion = RandomizedShip.Profile.Artillery.Dispersion;
                    }

                    */
                    Metrics.MainCaliber = artilleryExtractor.GunCaliber();
                    Metrics.Dispersion = artilleryExtractor.Dispersion();
                    Metrics.MainCaliberName = MData.Name;
                    Metrics.RotationTime = rotationTime;
                    Metrics.FireRateMain = fireRate;
                    Metrics.APDamage = apDamage;
                    Metrics.HEDamage = heDamage;

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
            Metrics.AirDetection = RandomizedShip.Profile.Concealment.AirDetection;
            Metrics.SurfaceDetection = RandomizedShip.Profile.Concealment.SurfaceDetection;
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
                //Console.WriteLine(CurrentModuleID + " : " + AllModules[CurrentModuleID.ToString()].Type + "=" + AllModules[CurrentModuleID.ToString()].Name);
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
    }
}
