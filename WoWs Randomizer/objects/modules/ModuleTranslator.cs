using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoWs_Randomizer.objects.module;

namespace WoWs_Randomizer.objects.modules
{
    class ModuleTranslator
    {
        public static void Transfer(ModuleData data)
        {
            if (data.Profile != null)
            {
                if ( data.Profile.ContainsKey("engine"))
                {
                    data.EngineSpeed = (double)data.Profile["engine"]["max_speed"];
                }
                if ( data.Profile.ContainsKey("hull"))
                {
                    data.HullHealth = Double.Parse(data.Profile["hull"]["health"].ToString());
                    try
                    {
                        if (data.Profile["hull"].ContainsKey("anti_aircraft_barrels"))
                        {
                            string value = data.Profile["hull"]["anti_aircraft_barrels"].ToString();
                            data.AABarrels = Double.Parse(value);
                        }
                        if (data.Profile["hull"].ContainsKey("torpedoes_barrels"))
                        {
                            string value = data.Profile["hull"]["torpedoes_barrels"].ToString();
                            data.TorpedoBarrels = Double.Parse(value);
                        }
                        if (data.Profile["hull"].ContainsKey("planes_amount"))
                        {
                            string value = data.Profile["hull"]["planes_amount"].ToString();
                            data.PlanesAmount = Double.Parse(value);
                        }
                        if (data.Profile["hull"].ContainsKey("artillery_barrels"))
                        {
                            string value = data.Profile["hull"]["artillery_barrels"].ToString();
                            data.ArtillerBarrels = Double.Parse(value);
                        }
                        if (data.Profile["hull"].ContainsKey("atba_barrels"))
                        {
                            string value = data.Profile["hull"]["atba_barrels"].ToString();
                            data.SecondaryBarrels = Double.Parse(value);
                        }
                    } catch(Exception e) { Console.WriteLine(e.Message + " / " + e.Source.ToString()); }

                }
                if ( data.Profile.ContainsKey("torpedoes"))
                {
                    data.TorpedoReload = Double.Parse(data.Profile["torpedoes"]["shot_speed"].ToString());
                    data.TorpedoRange = Double.Parse(data.Profile["torpedoes"]["distance"].ToString());
                    data.TorpedoDamage = Double.Parse(data.Profile["torpedoes"]["max_damage"].ToString());
                    data.TorpedoSpeed = Double.Parse(data.Profile["torpedoes"]["torpedo_speed"].ToString());
                }
                if ( data.Profile.ContainsKey("flight_control"))
                {
                    data.FighterSquadrons = long.Parse(data.Profile["flight_control"]["fighter_squadrons"].ToString());
                    data.BomberSquadrons = long.Parse(data.Profile["flight_control"]["bomber_squadrons"].ToString());
                    data.TorpedoSquadrons = long.Parse(data.Profile["flight_control"]["torpedo_squadrons"].ToString());
                }
                if ( data.Profile.ContainsKey("artillery"))
                {
                    ModuleArtillery Artillery = new ModuleArtillery();
                    Artillery.RotationTime = double.Parse(data.Profile["artillery"]["rotation_time"].ToString());
                    Artillery.GunRate = double.Parse(data.Profile["artillery"]["gun_rate"].ToString());

                    if (data.Profile["artillery"]["max_damage_AP"] != null)
                    {
                        Artillery.APDamage = long.Parse(data.Profile["artillery"]["max_damage_AP"].ToString());
                    }
                    if (data.Profile["artillery"]["max_damage_HE"] != null)
                    {
                        Artillery.HEDamage = long.Parse(data.Profile["artillery"]["max_damage_HE"].ToString());
                    }
                    data.Artillery = Artillery;
                }
                if ( data.Profile.ContainsKey("fire_control"))
                {
                    data.FireDistance = double.Parse(data.Profile["fire_control"]["distance"].ToString());
                    data.FireDistanceIncrease = double.Parse(data.Profile["fire_control"]["distance_increase"].ToString());
                }

            }
        }
    }
}
