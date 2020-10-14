﻿using System;
using System.Collections.Generic;
using WoWs_Randomizer.utils.ship;
using WoWs_Randomizer.utils;
using WoWs_Randomizer.objects.consumables;
using static WoWs_Randomizer.utils.ConsumableTypes;

namespace WoWs_Randomizer.utils.modules
{
    public class UpgradeCorrections
    {
        private Ship selectedShip = null;
        private List<long> corrections = new List<long>();
        private Dictionary<long, long> Legendary = new Dictionary<long, long>();

        public UpgradeCorrections(Ship selectedShip)
        {
            this.selectedShip = selectedShip;
            populateLegendaryList();

            corrections.Add(4221751216);
            corrections.Add(4218605488);
            corrections.Add(4216508336);
            populateCorrections();
        }

        public List<long> GetList() { return this.corrections; }

        public long GetLegendaryUpgrade()
        {
            if ( Legendary.ContainsKey(selectedShip.ID))
            {
                return Legendary[selectedShip.ID];
            }
            return 0;
        }

        public Dictionary<int,List<long>> GetSlotCorrections()
        {
            Dictionary<int, List<long>> SlotCorrections = new Dictionary<int, List<long>>();
            List<long> Slot1Upgrades = new List<long>();
            Slot1Upgrades.Add(4253208496);
            Slot1Upgrades.Add(4254257072);

            List<long> Slot2Upgrades = new List<long>();
            Slot2Upgrades.Add(4256354224);
            Slot2Upgrades.Add(4252159920);
            Slot2Upgrades.Add(4251111344);
            Slot2Upgrades.Add(4250062768);

            List<long> Slot3Upgrades = new List<long>();
            Slot3Upgrades.Add(4255305648);

            List<long> Slot5Upgrades = new List<long>();
            Slot5Upgrades.Add(4241674160);
            Slot5Upgrades.Add(4233285552);
            Slot5Upgrades.Add(4249014192);
            Slot5Upgrades.Add(4240625584);
            Slot5Upgrades.Add(4236431280);
            Slot5Upgrades.Add(4232236976);
            Slot5Upgrades.Add(4244819888);
            Slot5Upgrades.Add(4249014192);
            Slot5Upgrades.Add(4235382704);

            List<long> Slot6Upgrades = new List<long>();
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

            SlotCorrections.Add(1, Slot1Upgrades);
            SlotCorrections.Add(2, Slot2Upgrades);
            SlotCorrections.Add(3, Slot3Upgrades);
            SlotCorrections.Add(5, Slot5Upgrades);
            SlotCorrections.Add(6, Slot6Upgrades);

            return SlotCorrections;
        }

        private void populateLegendaryList()
        {
            Legendary.Add(4277090288, 4244819888); // Montana
            Legendary.Add(4179572688, 4249014192); // Conq.
            Legendary.Add(4179539760, 4249014192); // Hindenburg
            Legendary.Add(4179539792, 4241674160); // Henry IV
            Legendary.Add(4179539920, 4240625584); // Minotaur
            Legendary.Add(4074682352, 4238528432); // Worcester
            Legendary.Add(4179506640, 4236431280); // Khabarovsk
            Legendary.Add(4179506992, 4235382704); // Z-52
            Legendary.Add(4281219056, 4233285552); // Gearing
            Legendary.Add(4179506384, 4232236976); // Yueyang

            Legendary.Add(4179572560, 4247965616); // Republique
            Legendary.Add(4179572528, 4246917040); // Großer Kurfürst
            Legendary.Add(4276041424, 4245868464); // Yamato
            Legendary.Add(4259231440, 4243771312); // Zao
            Legendary.Add(4273911792, 4239577008); // Des Moines
            Legendary.Add(4179539408, 4237479856); // Moskva
            Legendary.Add(4282267344, 4234334128); // Shimakaze
            Legendary.Add(4074649040, 4231188400); // Grozovoi
            Legendary.Add(4179605488, 4230139824); // Midway
            Legendary.Add(4179605200, 4229091248); // Hakuryu
        }

        private void populateCorrections()
        {
            CVCorrections();
            if ( selectedShip.Tier >= 6)
            {
                corrections.Add(4253208496);
                addSpecialUpgrades();
            }
            if (Legendary.ContainsKey(selectedShip.ID))
            {
                corrections.Add(Legendary[selectedShip.ID]);
            }
        }

        private void addSpecialUpgrades()
        {
            if ( canEquipSpottingAircraftMod1())
            {
                corrections.Add(4254257072);
            }
            if ( canEquipEngineBoostMod1() )
            {
                corrections.Add(4256354224);
            }
            if ( canEquipDefAAMod1() )
            {
                corrections.Add(4252159920);
            }
            if ( canEquipHydroMod1() )
            {
                corrections.Add(4251111344);
            }
            if ( canEquipSRM1() )
            {
                corrections.Add(4250062768);
            }
            if ( canEquipSmokeGeneratorMod1() )
            {
                corrections.Add(4255305648);
            }
        }

        public bool canEquipDamageControlParty()
        {
            if (canEquipFastDamageControlTeam() ) { return false; }
            return true;
        }

        public bool canEquipFastDamageControlTeam()
        {
            if ( selectedShip.ShipType.ToLower().Equals(ShipTypes.BB.ToString()) && selectedShip.Tier >= 3 && selectedShip.Country.ToLower().Equals(Countries.USSR.ToString()))
            {
                return true;
            }
            return false;
        }

        public bool canEquipShortBurstSmoke()
        {
            List<long> canEquip = new List<long>();
            canEquip.Add(3751687984); // Z-35

            if ( canEquip.Contains(selectedShip.ID) || (selectedShip.Country.ToLower().Equals(Countries.UK.ToString()) && selectedShip.Tier >= 2))
            {
                return true;
            }
            return false;
        }

        public bool canEquipSmokeGeneratorMod1()
        {
            // Has Smoke Generator and therefore can equip Smoke Generator Mod 1
            List<long> canEquip = new List<long>();
            canEquip.Add(4267620048); // Iwaki Alpha
            canEquip.Add(3553540080); // Flint
            canEquip.Add(3751720944); // Anchorage
            canEquip.Add(3762206160); // Kutuzov
            canEquip.Add(3655251408); // Smolensk
            canEquip.Add(4184782800); // Emerald
            canEquip.Add(4183734224); // Leander
            canEquip.Add(4182685648); // Fiji
            canEquip.Add(3763255248); // Belfast
            canEquip.Add(4181637072); // Edinburgh
            canEquip.Add(4180588496); // Neptune
            canEquip.Add(4179539920); // Minotaur
            canEquip.Add(3767416176); // Vampire
            canEquip.Add(3764270928); // Aigle
            canEquip.Add(3764270288); // Anshan
            canEquip.Add(3762173136); // Loyang
            canEquip.Add(3767416784); // Campbeltown
            canEquip.Add(3764271056); // Gallant

            canEquip.Add(3769513264); // Blyskawica
            canEquip.Add(3760076080); // Friesland

            if (canEquip.Contains(selectedShip.ID))
            {
                return true;
            }
            else if (selectedShip.ShipType.Equals(ShipTypes.DD.ToString()) && selectedShip.Tier >= 2)
            {
                if (selectedShip.Country.ToLower().Equals(Countries.PAA.ToString()) || selectedShip.Country.ToLower().Equals(Countries.USA.ToString()) || (selectedShip.Country.ToLower().Equals(Countries.GER.ToString()) && selectedShip.ID != 3751687984) || selectedShip.Country.ToLower().Equals(Countries.JPN.ToString()) || selectedShip.Country.ToLower().Equals(Countries.USSR.ToString()))
                {
                    return true;
                }
            }
            return false;
        }

        public bool canEquipSRM1()
        {
            // Has Radar and therefore can equip Surveillance Radar Modification 1
            if (selectedShip.Tier >= 7)
            {
                List<long> canEquipSRM = new List<long>();
                canEquipSRM.Add(3761190896); // Missouri
                canEquipSRM.Add(3760109552); // Alaska
                canEquipSRM.Add(3666786288); // Alaska B
                canEquipSRM.Add(4180588528); // Buffalo
                canEquipSRM.Add(4180587984); // Donskoi
                canEquipSRM.Add(3761157584); // Kronshtadt
                canEquipSRM.Add(4180588496); // Neptune
                canEquipSRM.Add(4075730384); // Riga
                canEquipSRM.Add(4075730928); // Seattle
                canEquipSRM.Add(3551410160); // Black
                canEquipSRM.Add(4180554960); // Chung Mu
                canEquipSRM.Add(4074681808); // Aleksander Nevsky
                canEquipSRM.Add(4273911792); // Des Moines
                canEquipSRM.Add(4179539920); // Minotaur
                canEquipSRM.Add(4179539408); // Moskva
                canEquipSRM.Add(3969824208); // Petropavlovsk
                canEquipSRM.Add(3655251952); // Puerto Rico
                canEquipSRM.Add(3550394352); // Salem
                canEquipSRM.Add(3760109008); // Stalingrad
                canEquipSRM.Add(3749623248); // Stalingrad #2
                canEquipSRM.Add(4074682352); // Worcester
                canEquipSRM.Add(4179506384); // Yueyang
                canEquipSRM.Add(3655218480); // Småland
                canEquipSRM.Add(3542005744); // AL Montpelier
                canEquipSRM.Add(4288591856); // Atlanta
                canEquipSRM.Add(3763255248); // Belfast
                canEquipSRM.Add(3763255280); // Indianapolis
                canEquipSRM.Add(4076778960); // Tallinn
                canEquipSRM.Add(3762206704); // Wichita
                canEquipSRM.Add(4181603536); // Hsienyang
                canEquipSRM.Add(3762173232); // Orkan
                canEquipSRM.Add(4181637104); // Baltimore
                canEquipSRM.Add(4181636560); // Chapayev
                canEquipSRM.Add(4076779504); // Cleveland
                canEquipSRM.Add(4181637072); // Edinburgh
                canEquipSRM.Add(3741234640); // Ochakov

                if (canEquipSRM.Contains(selectedShip.ID))
                {
                    return true;
                }
            }
            return false;
        }

        public bool canEquipHydroMod1()
        {
            // 3742316496 - Duke of York
            // 3764303600 - Duca d'Aosta - Duca d'Aosta
            // 3763255024 - Duca degli Abruzzi
            // 3658397424 - Gorizia
            // 3762173136 - Loyang
            // 4076745936 - Siliwangi
            // 3760076080 - Friesland

            // Has Hydro and therefore can equip Hydroacoustic Search Mod 1
            if (selectedShip.ID == 3742316496 || selectedShip.ID == 3764303600 || selectedShip.ID == 3763255024 || selectedShip.ID == 3658397424 || selectedShip.ID == 3762173136 || selectedShip.ID == 4076745936 || selectedShip.ID == 3760076080)
            {
                return true;
            }
            else if (selectedShip.Country.ToLower().Equals(Countries.GER.ToString()) && !selectedShip.ShipType.ToLower().Equals(ShipTypes.CV.ToString()))
            {
                return true;
            }
            else if (selectedShip.ShipType.ToLower().Equals(ShipTypes.CA.ToString()) && !selectedShip.Country.ToLower().Equals(Countries.ITA.ToString()))
            {
                if ( selectedShip.ID != 4290688720 ) // Yubari can not equip
                {
                    return true;
                }
            } else if ( selectedShip.ShipType.ToLower().Equals(ShipTypes.SM.ToString()) && selectedShip.Country.ToLower().Equals(Countries.GER.ToString()))
            {
                return true;
            }
            return false;
        }

        public bool canEquipShortRangeHydro()
        {
            if ( selectedShip.Tier >= 6 && selectedShip.ShipType.ToLower().Equals(ShipTypes.DD.ToString()) && selectedShip.Country.ToLower().Equals(Countries.UK.ToString()) && selectedShip.ID != 3764271056 )
            {
                return true;
            } else if ( selectedShip.ID == 3763221872)
            {
                return true;
            }

            return false;
        }
        public bool canEquipDefAAMod1()
        {
            // Has Defensive AA and therefore can equip the Defensive AA Fire Mod 1
            if (selectedShip.Tier >= 8)
            {
                if (selectedShip.Country.ToLower().Equals(Countries.UK.ToString()) && selectedShip.ShipType.ToLower().Equals(ShipTypes.CA.ToString()))
                {
                    // Only heavy cruisers...
                    if (selectedShip.ID == 4076779472 || selectedShip.ID == 4075730896 || selectedShip.ID == 4074682320 || selectedShip.ID == 3762206672)
                    {
                        return true;
                    }
                }
                else if (selectedShip.ID == 3760142288 || selectedShip.ID == 3751720144 || selectedShip.ID == 3762173136 || selectedShip.ID == 4076746192 || selectedShip.ID == 4182652368 || selectedShip.ID == 4074649040 || selectedShip.ID == 4074649424 || selectedShip.ID == 3760142288 || selectedShip.ID == 3760109008 || selectedShip.ID == 3749623248 || selectedShip.ID == 4179539408 || selectedShip.ID == 3969824208)
                {
                    // 3751720144 - Wukong
                    // 3762173136 - Loyang
                    // 4076746192 - Ognevoi
                    // 4182652368 - Udaloi
                    // 4074649040 - Grozovoi
                    // 4074649424 - Marceau
                    // 3760142288 - Thunderer
                    // 3760109008 - Stalingrad
                    // 3749623248 - Stalingrad #2
                    // 4179539408 - Moskva
                    // 3969824208 - Petropavlovsk
                    // 3760142288 - Thunderer
                    return true;
                }
                else if (selectedShip.Country.ToLower().Equals(Countries.USA.ToString()) && selectedShip.ShipType.ToLower().Equals(ShipTypes.DD.ToString()) && selectedShip.Premium == false)
                {
                    // Tech-tree destroyers only
                    return true;
                } else if ( selectedShip.Country.ToLower().Equals(Countries.USA.ToString()) && selectedShip.ShipType.ToLower().Equals(ShipTypes.DD.ToString()))
                {
                    // 3764271088 - Monaghan
                    // 4264441840 - Sims
                    // 3668850672 - Sims B
                    // 3762173936 - Kidd
                    // 3761125360 - Benham
                    // 3551410160 - Black
                    if ( selectedShip.ID == 3764271088 || selectedShip.ID == 4264441840 || selectedShip.ID == 3668850672 || selectedShip.ID == 3762173936 || selectedShip.ID == 3761125360 || selectedShip.ID == 3551410160)
                    {
                        return true;
                    }
                }
                else if (selectedShip.ShipType.ToLower().Equals(ShipTypes.CA.ToString()))
                {
                    if (selectedShip.Country.ToLower().Equals(Countries.USA.ToString()) || selectedShip.Country.ToLower().Equals(Countries.JPN.ToString()) || selectedShip.Country.ToLower().Equals(Countries.GER.ToString()) || selectedShip.Country.ToLower().Equals(Countries.FRA.ToString()) || selectedShip.Country.ToLower().Equals(Countries.USSR.ToString()))
                    {
                        return true;
                    }
                }
                else if (selectedShip.Country.ToLower().Equals(Countries.EUR.ToString()) && selectedShip.ShipType.ToLower().Equals(ShipTypes.DD.ToString()))
                {
                    return true;
                }
            }
            else
            {
                // 3763288016 - Hood
                // 4288591856 - Atlanta
                // 3553540080 - Flint
                // 4290688720 - Yubari
                // IJN, GER FRA USSR cruisers from tier 6
                // RN Heavy cruisers (tier 7)
                // 4077828048- Surrey
                // 3764303600 - Duca d'Aosta
                // 3763255024 - Duca degli Abruzzi
                // 3764271088 - Monaghan
                // 4264441840 - Sims
                // 3668850672 - Sims B
                if ( selectedShip.ID == 3763288016 ||
                    selectedShip.ID == 4288591856 ||
                    selectedShip.ID == 4290688720 ||
                    selectedShip.ID == 4077828048 ||
                    selectedShip.ID == 3764303600 ||
                    selectedShip.ID == 3763255024 ||
                    selectedShip.ID == 3764271088 ||
                    selectedShip.ID == 4264441840 ||
                    selectedShip.ID == 3668850672
                    )
                {
                    return true;
                } else if (selectedShip.ShipType.ToLower().Equals(ShipTypes.CA.ToString()) && (selectedShip.Country.ToLower().Equals(Countries.JPN) || selectedShip.Country.ToLower().Equals(Countries.GER) || selectedShip.Country.ToLower().Equals(Countries.FRA) || selectedShip.Country.ToLower().Equals(Countries.USSR)) && selectedShip.Tier >= 6)
                {
                    return true;
                }
            }
            return false;
        }

        public bool canEquipEngineBoostMod1()
        {
            // Has engine boost and therefore can equip the Engine Boost Mod 1
            if (selectedShip.ID == 3764271056 || selectedShip.ID == 3752736720 || selectedShip.ID == 3764270928 || selectedShip.ID == 3762173776 || selectedShip.ID == 3530504176 || selectedShip.ID == 3767416784 || selectedShip.ID == 3766368080 || selectedShip.ID == 3760142160 || selectedShip.ID == 4076746192 || selectedShip.ID == 4182652368 || selectedShip.ID == 4074649040)
            {
                // 3764271056 - Gallant
                // 3752736720 - Cossack
                // 3764270928 - Aigle
                // 3762173776 - Le Terrible
                // 3530504176 - Georgia
                // 3767416784 - Campbeltown
                // 3766368080 - Siroco
                // 3760142160 - Bourgogne
                // 4076746192 - Ognevoi
                // 4182652368 - Udaloi
                // 4074649040 - Grozovoi

                return true;
            }
            
            else if (selectedShip.Country.ToLower().Equals(Countries.FRA.ToString()))
            {
                if ( selectedShip.ShipType.ToLower().Equals(ShipTypes.BB.ToString()) && selectedShip.Tier >= 8)
                {
                    return true;
                } else if ( selectedShip.ShipType.ToLower().Equals(ShipTypes.CA.ToString()) && selectedShip.Tier >= 6)
                {
                    return true;
                } else if ( selectedShip.ShipType.ToLower().Equals(ShipTypes.DD.ToString()) && selectedShip.Tier >= 2)
                {
                    return true;
                }
                return false;
            } 

            else if (selectedShip.Country.ToLower().Equals(Countries.EUR.ToString()) || selectedShip.Country.ToLower().Equals(Countries.JPN.ToString()) || selectedShip.Country.ToLower().Equals(Countries.USA.ToString()) || selectedShip.Country.ToLower().Equals(Countries.USSR.ToString()) || selectedShip.Country.ToLower().Equals(Countries.GER.ToString()) || selectedShip.Country.ToLower().Equals(Countries.CW.ToString()) || selectedShip.Country.ToLower().Equals(Countries.PAA.ToString()))
            {
                if (selectedShip.ShipType.ToLower().Equals(ShipTypes.DD.ToString()) && selectedShip.ID != 3760076080 && canEquipEmergencyEnginePower() == false)
                {
                    // 3760076080 - Friesland
                    return true;
                }
            }
            return false;
        }

        public bool canEquipEmergencyEnginePower()
        {
            // 3655218480 - Småland
            // 3761125104 - Paolo emilio
            if ( selectedShip.ID == 3655218480 || selectedShip.ID == 3761125104)
            {
                return true;
            }
            return false;
        }

        public bool canEquipSpottingAircraftMod1()
        {
            // Has Spotting aircraft consumable - can equip Spotting Aircraft Modification 1
            if (selectedShip.Country.ToLower().Equals(Countries.USA.ToString()) && selectedShip.ShipType.ToLower().Equals(ShipTypes.BB.ToString()) && selectedShip.ID != 3761190896)
            {
                // 3761190896 - Missouri
                return true;
            }
            else if (selectedShip.Country.ToLower().Equals(Countries.USA.ToString()) && selectedShip.ShipType.ToLower().Equals(ShipTypes.CA.ToString()))
            {
                // 4076779504 - Cleveland
                // 4180588528 - Buffalo
                // 4273911792 - Des Moines
                // 4075730928 - Seattle
                // 4074682352 - Worcester
                // 3762206704 - Wichita
                // 3542005744 - AL Montpelieer
                // 3751720944 - Anchorage
                // 3760109552 - Alaska
                // 3666786288 - Alaska B
                // 3655251952 - Puerto Rico
                // 4180588368 - Saint-Louis
                if (selectedShip.ID == 4076779504 || 
                    selectedShip.ID == 4180588528 || 
                    selectedShip.ID == 4273911792 || 
                    selectedShip.ID == 4075730928 || 
                    selectedShip.ID == 4074682352 ||
                    selectedShip.ID == 3762206704 || 
                    selectedShip.ID == 3542005744 || 
                    selectedShip.ID == 3542005744 ||
                    selectedShip.ID == 3751720944 ||
                    selectedShip.ID == 3666786288 || 
                    selectedShip.ID == 3760109552 || 
                    selectedShip.ID == 4180588368 ||
                    selectedShip.ID == 3655251952)
                {
                    return true;
                }
            }
            else if (selectedShip.Country.ToLower().Equals(Countries.JPN.ToString()) && selectedShip.ShipType.ToLower().Equals(ShipTypes.BB.ToString()))
            {
                // 4286527184 - Ishizuchi
                // 3763287760 - Ashitaka
                if (selectedShip.ID != 4286527184 && selectedShip.ID != 3763287760)
                {
                    return true;
                }
            }
            else if (selectedShip.Country.ToLower().Equals(Countries.USSR.ToString()) && selectedShip.ShipType.ToLower().Equals(ShipTypes.CA.ToString()))
            {
                // 4069438928 - Kotovsky
                // 4184782288 - Kirov
                // 3754866128 - Mikoyan
                // 4291737040 - Murmansk
                // 4183733712 - Budyonny
                // 3764303312 - Molotov
                // 4182685136 - Shchors
                // 3751720400 - Lazo
                // 4075730384 - Riga
                // 3761157584 - Kronshtadt
                if ( selectedShip.ID == 4069438928 || selectedShip.ID == 4184782288 || selectedShip.ID == 3754866128 || selectedShip.ID == 4291737040 || selectedShip.ID == 4183733712 || selectedShip.ID == 3764303312 || selectedShip.ID == 4182685136 || selectedShip.ID == 3751720400 || selectedShip.ID == 4075730384 || selectedShip.ID == 3761157584)
                {
                    return true;
                }
            }
            else if (selectedShip.Country.ToLower().Equals(Countries.GER.ToString()))
            {
                if ( selectedShip.ShipType.ToLower().Equals(ShipTypes.BB.ToString()) && !(selectedShip.ID != 3764336432 || selectedShip.ID != 3761190704))
                {
                    // 3764336432 - PEE Friedrich
                    // 3761190704 - Pommern
                    return true;

                } else if ( selectedShip.ShipType.ToLower().Equals(ShipTypes.CA.ToString()) && (selectedShip.ID == 4180588336 || selectedShip.ID == 4179539760 || selectedShip.ID == 3761157936 || selectedShip.ID == 3340678960))
                {
                    // 4180588336 - Roon
                    // 3340678960 - [Hindenburg]
                    // 4179539760 - Hindnburg
                    // 3761157936 - Siegfried
                    return true;
                }
            }
            else if ((selectedShip.Country.ToLower().Equals(Countries.UK.ToString()) && selectedShip.ShipType.ToLower().Equals(ShipTypes.BB.ToString()) && selectedShip.Premium == false) || selectedShip.ID == 4292818896)
            {
                // 4292818896 - Warspite
                // UK BB's Tech-tree and warspite
                return true;
            }
            else if (selectedShip.Country.ToLower().Equals(Countries.UK.ToString()) && selectedShip.ShipType.ToLower().Equals(ShipTypes.CA.ToString()))
            {
                // 4184782800 - Emerald
                // 4183734224 - Leander
                // 4181637072 - Edinburgh
                // 4182685648 - Fiji
                // 4077828048 - Surrey
                // 4076779472 - Albermarle
                // 4075730896 - Drake
                if (selectedShip.ID == 4184782800 || selectedShip.ID == 4183734224 || selectedShip.ID == 4181637072 || selectedShip.ID == 4182685648 || selectedShip.ID == 4077828048 || selectedShip.ID == 4076779472 || selectedShip.ID == 4075730896)
                {
                    return true;
                }
            }
            else if (selectedShip.Country.ToLower().Equals(Countries.ITA.ToString()) && selectedShip.ShipType.ToLower().Equals(ShipTypes.CA.ToString()))
            {
                return true;
            }
            else
            {
                List<long> specific = new List<long>();
                specific.Add(3760109264); // Azuma
                specific.Add(3749623504); // Yoshino
                specific.Add(4282300112); // Ibuki
                specific.Add(4259231440); // Zao
                specific.Add(3315513040); // [Zao]
                specific.Add(3764303216); // Perth
                specific.Add(3751720144); // Wukong
                specific.Add(3762239216); // Roma
                specific.Add(3762239312); // Gascogne
                specific.Add(4181669712); // Richelieu
                specific.Add(3761190096); // Baije
                specific.Add(3741267792); // Champagne
                specific.Add(3552524016); // AL Littorio
                specific.Add(3764336464); // Dunkerque
                specific.Add(3761190608); // Musashi
                if (specific.Contains(selectedShip.ID))
                {
                    return true;
                }
            }
            return false;
        }

        public bool canEquipRepairParty()
        {
            if ( selectedShip.Tier >= 2 )
            {
                if ( selectedShip.ShipType.ToLower().Equals(ShipTypes.BB.ToString()))
                {
                    // US BB Premiums Tier 3 - 9
                    if ( selectedShip.Country.ToLower().Equals(Countries.USA.ToString()) && selectedShip.Premium == true && (selectedShip.Tier >= 3 && selectedShip.Tier <= 9)) 
                    {
                        return true;
                    }
                    // US BB Massachuetts/B, Gorgia, Ohio, Thunderer
                    if ( selectedShip.ID == 3751753712 || selectedShip.ID == 3667867632 || selectedShip.ID == 3530504176 || selectedShip.ID == 3760142320 || selectedShip.ID == 3760142288)
                    {
                        return true;
                    }
                    // US BB Techtree, tier 3-10
                    if ( selectedShip.Country.ToLower().Equals(Countries.USA.ToString()) && selectedShip.Tier >= 3 && selectedShip.Premium == false )
                    {
                        return true;
                    }
                    // IJN, GER, FRA, ITA, USSR - BB - Tier 2-10
                    if ( selectedShip.Country.ToLower().Equals(Countries.JPN.ToString()) ||
                        selectedShip.Country.ToLower().Equals(Countries.GER.ToString()) ||
                        selectedShip.Country.ToLower().Equals(Countries.FRA.ToString()) ||
                        selectedShip.Country.ToLower().Equals(Countries.ITA.ToString()) ||
                        selectedShip.Country.ToLower().Equals(Countries.USSR.ToString())
                        )
                    {
                        return true;
                    }
                    // RN BB tier 2-8 (upper tier using specialized heal)
                    if ( selectedShip.Country.ToLower().Equals(Countries.UK.ToString()) && selectedShip.Tier <= 8)
                    {
                        return true;
                    }
                } else if ( selectedShip.ShipType.ToLower().Equals(ShipTypes.CA.ToString()))
                {
                    // RN Cruisers, tier 3 - 7, Higher tires using specialized heal
                    if ( selectedShip.Tier >= 3 && selectedShip.Tier <= 7 && selectedShip.Country.ToLower().Equals(Countries.UK.ToString()))
                    {
                        return true;
                    }
                    if ( selectedShip.Country.ToLower().Equals(Countries.USA.ToString()) ||
                        selectedShip.Country.ToLower().Equals(Countries.JPN.ToString()) ||
                        selectedShip.Country.ToLower().Equals(Countries.USSR.ToString()) ||
                        selectedShip.Country.ToLower().Equals(Countries.FRA.ToString()) ||
                        selectedShip.Country.ToLower().Equals(Countries.ITA.ToString()) ||
                        selectedShip.Country.ToLower().Equals(Countries.GER.ToString())
                        )
                    {
                        if ( selectedShip.Tier >= 9 )
                        {
                            return true;
                        }
                    }
                    // Prinz Eugen, Duca degli Abruzzi
                    if ( selectedShip.ID == 3762206512 || selectedShip.ID == 3763255024)
                    {
                        return true;
                    }
                } else if ( selectedShip.ShipType.ToLower().Equals(ShipTypes.DD.ToString()))
                {
                    if ( selectedShip.Country.ToLower().Equals(Countries.USSR.ToString()) && selectedShip.Tier >= 8)
                    {
                        return true;
                    }
                    if ( selectedShip.Country.ToLower().Equals(Countries.UK.ToString()) && selectedShip.Tier >= 9 )
                    {
                        return true;
                    }
                    if ( selectedShip.Country.ToLower().Equals(Countries.EUR.ToString()) && selectedShip.Tier >= 5)
                    {
                        return true;
                    }
                    // Kidd
                    if ( selectedShip.ID == 3762173936)
                    {
                        return true;
                    }
                } else if ( selectedShip.ShipType.ToLower().Equals(ShipTypes.SM.ToString()) && selectedShip.Country.ToLower().Equals(Countries.USSR.ToString()) && selectedShip.Tier == 6){
                    return true;
                }
            }
            return false;
        }

        public bool canEquipSpecializedHeal()
        {
            // UK Cruisers tier 8-10
            if ( selectedShip.Country.ToLower().Equals(Countries.UK.ToString()) && selectedShip.Tier >= 8 && selectedShip.ShipType.ToLower().Equals(ShipTypes.CA.ToString()))
            {
                return true;
            }
            // UK BB Tier 9-10
            if ( selectedShip.Country.ToLower().Equals(Countries.UK.ToString()) && selectedShip.ShipType.ToLower().Equals(ShipTypes.BB.ToString()) && selectedShip.Tier >=9 )
            {
                return true;
            }
            List<long> specific = new List<long>();
            specific.Add(3752802256); // Nelson
            specific.Add(3668883440); // Boise
            specific.Add(3550394352); // Salem
            specific.Add(3762206672); // Cheeshire
            specific.Add(4076779472); // Albemarle
            specific.Add(4075730896); // Drake
            specific.Add(4074682320); // Goliath
            specific.Add(3763254608); // Nueve de Julio
            specific.Add(3551409616); // Neustrashimy
            return specific.Contains(selectedShip.ID);
        }

        public bool canEquipCatapultFighter()
        {
            // US, IJN, RN, GER, FRA, USSR - BB - Tier 7-8, except Lyon, Hood, Nelson, Duke of York, Vanguard, Ashitaka
            // US, IJN, RN, GER, FRA, USSR, PAA - BB - Tier 9, except Missouri, Pommern and Jean Bart
            // US, IJN, GER - BB - Tier 10
            // US, IJN, RN, Commonwealth, GER, FRA, ITA - Cruisers - Tier 5-6, except hawkins, Devonshire, La Galissionnaire, London and Duca d'Aosta
            // US, IJN, RN, GER, FRA, ITA - Cruisers - Tier 7-8, Except Surrey, Albemarle, Gorizia, Duca degli Abruzzi, Atlanta/B, Boise, Flint, Belfast, Bayard, Wichita, Cheshire, AL Montpelier
            // US, IJN, GER, FRA, ITA, USSR - Cruisers - Tier 9, Except Dmitri Donskoi, Kronshtadt, Ägir, Azuma
            // US, IJN, GER, ITA - Cruisers - Tier 10, Except Salem

            List<long> exceptions = new List<long>();
            List<long> canAdd = new List<long>();
            exceptions.Add(4182718288); // Lyon
            exceptions.Add(3763288016); // Hood
            exceptions.Add(3752802256); // Nelson
            exceptions.Add(3742316496); // Duke of York
            exceptions.Add(3762239440); // Vanguard
            exceptions.Add(3763287760); // Ashitaka
            exceptions.Add(3761190896); // Missouri
            exceptions.Add(3761190704); // Pommern
            exceptions.Add(3751753552); // Jean Bart
            exceptions.Add(4079925200); // hawkins
            exceptions.Add(4078876624); // Devonshire
            exceptions.Add(4183734096); // La Galissionnaire
            exceptions.Add(3753818064); // London
            exceptions.Add(3764303600); // Duca d'Aosta
            exceptions.Add(4077828048); // Surrey
            exceptions.Add(4076779472); // Albemarle
            exceptions.Add(3658397424); // Gorizia
            exceptions.Add(3763255024); // Duca degli Abruzzi
            exceptions.Add(4288591856); // Atlanta
            exceptions.Add(3668883440); // Boise
            exceptions.Add(3553540080); // Flint
            exceptions.Add(3763255248); // Belfast
            exceptions.Add(3762206544); // Bayard
            exceptions.Add(3762206704); // Wichita
            exceptions.Add(3762206672); // Cheshire
            exceptions.Add(3542005744); // AL Montpelier
            exceptions.Add(4180587984); // Dmitri Donskoi
            exceptions.Add(3761157584); // Kronshtadt
            exceptions.Add(3750672176); // Ägir
            exceptions.Add(3760109264); // Azuma
            exceptions.Add(3550394352); // Salem

            canAdd.Add(3764336464); // Dunkerque
            canAdd.Add(3761190608); // Musashi
            canAdd.Add(3767449296); // Katori
            canAdd.Add(4281251536); // Kuma
            canAdd.Add(4185831248); // Duguay-Trouin
            canAdd.Add(4184782288); // Kirov
            canAdd.Add(3751720944); // Anchorage

            if ( exceptions.Contains(selectedShip.ID)) { return false;  }
            if ( canAdd.Contains(selectedShip.ID)) { return true;  }

            if ( selectedShip.ShipType.ToLower().Equals(ShipTypes.BB.ToString()))
            {
                if ( selectedShip.Country.ToLower().Equals(Countries.USA.ToString()) ||
                    selectedShip.Country.ToLower().Equals(Countries.JPN.ToString()) ||
                    selectedShip.Country.ToLower().Equals(Countries.UK.ToString()) ||
                    selectedShip.Country.ToLower().Equals(Countries.GER.ToString()) ||
                    selectedShip.Country.ToLower().Equals(Countries.FRA.ToString()) ||
                    selectedShip.Country.ToLower().Equals(Countries.USSR.ToString())
                    )
                {
                    if ( selectedShip.Tier == 7 || selectedShip.Tier == 8 || selectedShip.Tier == 9)
                    {
                        return true;
                    }
                }
                if ( selectedShip.Country.ToLower().Equals(Countries.PAA.ToString()) && selectedShip.Tier == 9)
                {
                    return true;
                }
                if (selectedShip.Country.ToLower().Equals(Countries.USA.ToString()) ||
                    selectedShip.Country.ToLower().Equals(Countries.JPN.ToString()) ||
                    selectedShip.Country.ToLower().Equals(Countries.GER.ToString())
                    )
                {
                    if ( selectedShip.Tier == 10)
                    {
                        return true;
                    }
                }
            } else if ( selectedShip.ShipType.ToLower().Equals(ShipTypes.CA.ToString()))
            {
                if (selectedShip.Country.ToLower().Equals(Countries.USA.ToString()) ||
                    selectedShip.Country.ToLower().Equals(Countries.JPN.ToString()) ||
                    selectedShip.Country.ToLower().Equals(Countries.CW.ToString()) ||
                    selectedShip.Country.ToLower().Equals(Countries.GER.ToString()) ||
                    selectedShip.Country.ToLower().Equals(Countries.FRA.ToString()) ||
                    selectedShip.Country.ToLower().Equals(Countries.ITA.ToString()) ||
                    selectedShip.Country.ToLower().Equals(Countries.UK.ToString())
                    )
                {
                    if (selectedShip.Tier == 5 || selectedShip.Tier == 6)
                    {
                        return true;
                    }
                }
                if (selectedShip.Country.ToLower().Equals(Countries.USA.ToString()) ||
                    selectedShip.Country.ToLower().Equals(Countries.JPN.ToString()) ||
                    selectedShip.Country.ToLower().Equals(Countries.GER.ToString()) ||
                    selectedShip.Country.ToLower().Equals(Countries.FRA.ToString()) ||
                    selectedShip.Country.ToLower().Equals(Countries.ITA.ToString()) ||
                    selectedShip.Country.ToLower().Equals(Countries.UK.ToString())
                    )
                {
                    if (selectedShip.Tier == 7 || selectedShip.Tier == 8)
                    {
                        return true;
                    }
                }
                if (selectedShip.Country.ToLower().Equals(Countries.USA.ToString()) ||
                    selectedShip.Country.ToLower().Equals(Countries.JPN.ToString()) ||
                    selectedShip.Country.ToLower().Equals(Countries.GER.ToString()) ||
                    selectedShip.Country.ToLower().Equals(Countries.FRA.ToString()) ||
                    selectedShip.Country.ToLower().Equals(Countries.ITA.ToString()) ||
                    selectedShip.Country.ToLower().Equals(Countries.USSR.ToString()) ||
                    selectedShip.Country.ToLower().Equals(Countries.UK.ToString())
                    )
                {
                    if (selectedShip.Tier == 9)
                    {
                        return true;
                    }
                }
                if (selectedShip.Country.ToLower().Equals(Countries.USA.ToString()) ||
                    selectedShip.Country.ToLower().Equals(Countries.JPN.ToString()) ||
                    selectedShip.Country.ToLower().Equals(Countries.GER.ToString()) ||
                    selectedShip.Country.ToLower().Equals(Countries.ITA.ToString())
                    )
                {
                    if (selectedShip.Tier == 10)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool canEquipCrawlingSmoke()
        {
            List<long> canEquip = new List<long>();
            canEquip.Add(3764303056); // Huanghe
            canEquip.Add(3764303216); // Perth
            canEquip.Add(3763221872); // Haida
            return canEquip.Contains(selectedShip.ID);
        }

        public bool canEquipExhaustSmoke()
        {
            //Italian cruisers from tier 5 and up.
            if ( selectedShip.Tier >= 5 && selectedShip.Country.ToLower().Equals(Countries.ITA.ToString()))
            {
                return true;
            }
            return false;
        }

        public bool canEquipMainBatteryReloadBooster()
        {
            if ( selectedShip.Country.ToLower().Equals(Countries.FRA.ToString()))
            {
                // All FRA DD's excpt Aigle and Mareau
                if ( selectedShip.ShipType.ToLower().Equals(ShipTypes.DD.ToString()) && !(selectedShip.ID == 3764270928 || selectedShip.ID == 4074649424))
                {
                    return true;
                }
                // All FRA CA's excpt De Grasse
                if ( selectedShip.ShipType.ToLower().Equals(ShipTypes.CA.ToString()) && selectedShip.ID != 3764303696)
                {
                    return true;
                }
                List<long> canEquip = new List<long>();
                canEquip.Add(3751753552); // Jean Bart
                canEquip.Add(3760142160); // Bourgogne
                canEquip.Add(3760142160); // Siroco
                return canEquip.Contains(selectedShip.ID);
            }

            return false;
        }

        public bool canEquipTorpReloadBooster()
        {
            List<long> canEquip = new List<long>();
            canEquip.Add(3764271088); // Monaghan
            canEquip.Add(4077795024); // Shiratsuyu
            canEquip.Add(4181604048); // Akizuki
            canEquip.Add(4065212112); // Kitakaze
            canEquip.Add(4074649296); // Harugumo
            canEquip.Add(4076746448); // Kagero
            canEquip.Add(4075697872); // Yugumo
            canEquip.Add(3552458448); // HSF Harekaze
            canEquip.Add(3760076496); // Hayate
            canEquip.Add(3764303056); // Huanghe
            canEquip.Add(3762205904); // Irian
            canEquip.Add(3751720144); // Wukong
            return canEquip.Contains(selectedShip.ID);
        }

        // CV consumables
        public bool canEquipCAPFighters()
        {
            if ( selectedShip.ShipType.ToLower().Equals(ShipTypes.CV.ToString()) && selectedShip.Tier >= 4)
            {
                return true;
            }
            return false;
        }

        public bool canEquipEngineCooling()
        {
            if ( selectedShip.ShipType.ToLower().Equals(ShipTypes.CV.ToString()) && selectedShip.Tier >= 4)
            {
                return true;
            }
            return false;
        }

        public bool canEquipPatrolFighters()
        {
            if (selectedShip.ShipType.ToLower().Equals(ShipTypes.CV.ToString()) && selectedShip.Tier >= 6)
            {
                return true;
            }
            return false;
        }

        public bool canEquipAircraftRepair()
        {
            if (selectedShip.ShipType.ToLower().Equals(ShipTypes.CV.ToString()) && selectedShip.Tier >= 8)
            {
                return true;
            }
            return false;
        }

        // Submarine consumables

        public bool canEquipMaxDepth()
        {
            if ( selectedShip.ShipType.ToLower().Equals(ShipTypes.SM.ToString()))
            {
                return true;
            }
            return false;
        }

        private void CVCorrections()
        {
            if (selectedShip.ShipType.ToLower().Equals(ShipTypes.CV.ToString()))
            {
                corrections.Add(4223848368);
                corrections.Add(4226994096);
                corrections.Add(4224896944);
                corrections.Add(4219654064);
                corrections.Add(4229091248);
            }
        }

        public static string GetConsumableInfoGroupSelection(long groupId)
        {
            Dictionary<long, string> map = new Dictionary<long, string>();
            // a = All ships, t = Tech-tree ships only, p = premium only

            // HYDRO
            map.Add(1, "Battleship/9,10/germany/a");
            map.Add(2, "Cruiser/4,5,6,7/usa,japan,ussr,uk,france,pan_asia,commonwealth,pan_america/a");
            map.Add(3, "Cruiser/8,9,10/usa,japan,ussr,uk,france,pan_asia,commonwealth,pan_america/a");
            map.Add(4, "Cruiser/4,5,6,7/germany/a");
            map.Add(5, "Cruiser/8,9,10/germany/a");
            map.Add(6, "Destroyer/4,5,6,7/germany/a");
            map.Add(7, "Destroyer/8,9,10/germany/a");
            // SHORT RANGE HYDRO
            map.Add(8, "Destroyer/6,7,8,9,10/uk/a");
            // FAST DAMAGE CONTROL TEAM
            map.Add(9, "Battleship/3,4,5,6,7,8,9,10/ussr/a");
            // DAMAGE CONTROL PARTY
            map.Add(10, "Battleship/3,4,5,6,7,8,9,10/usa/a");
            map.Add(11, "Battleship/2,3,4,5,6,7,8,9,10/japan/a");
            map.Add(12, "Battleship/3,4,5,6,7,8,9,10/germany,uk,france,italy,pan_asia,europe/a");
            map.Add(13, "Cruiser/1/usa,japan,ussr,germany,uk,france,italy,pan_asia,europe/a");
            map.Add(14, "Cruiser/2,3,4,5,6,7,8,9,10/usa,japan,ussr,germany,uk,france,italy,pan_asia,commonwealth,pan_america/a");
            map.Add(15, "Destroyer/2,3,4,5,6,7,8,9,10/usa,japan,ussr,germany,uk,france,pan_asia,commonwealth,europe/a");
            map.Add(75, "AirCarrier/4,6,8,10/usa,japan,germany,uk/a");

            // REPAIR PARTY
            map.Add(16, "Battleship/3,4,5,6,7,8,9,10/usa/a");
            map.Add(17, "Battleship/2,3,4,5,6,7,8/japan,germany,france,italy/a");
            map.Add(18, "Battleship/9,10/japan,germany,italy/a");
            map.Add(19, "Battleship/3,4,5,6,7,8,9,10/ussr/a");
            map.Add(20, "Battleship/2,3/uk/a");
            map.Add(21, "Battleship/4,5,6/uk/a");
            map.Add(22, "Battleship/7,8/uk/a");
            map.Add(23, "Cruiser/9,10/usa,japan,ussr,france,italy/a");
            map.Add(24, "Cruiser/9,10/germany/a");
            map.Add(25, "Destroyer/9,10/uk/a");
            // SPECIALIZED HEAL
            map.Add(26, "Battleship/9,10/uk/a");
            map.Add(27, "Cruiser/8,9,10/uk/a");
            // CATAPULT FIGHTER
            map.Add(28, "Battleship/7,8/usa,japan,uk,germany,france,ussr/a");
            map.Add(29, "Battleship/9/usa,japan,germany,uk,france,pan_asia,ussr/a");
            map.Add(30, "Battleship/10/usa,japan,germany/a");
            map.Add(31, "Cruiser/5,6/usa,japan,uk,commonwealth,germany,italy,france/a");
            map.Add(32, "Cruiser/7,8/usa,japan,uk,germany,italy,france/a");
            map.Add(33, "Cruiser/9/usa,japan,germany,italy,france,ussr/a");
            map.Add(34, "Cruiser/10/usa,japan,germany,italy/a");
            // SPOTTER PLANE
            map.Add(35, "Battleship/4,5,6,7,8,9,10/usa,japan/a");
            map.Add(36, "Battleship/5,6,7,8,9,10/germany/a");
            map.Add(37, "Battleship/5,6,7,8,9/uk/t");
            map.Add(38, "Cruiser/5,6,7,8,9,10/italy/a");
            // SHORT-BURST SMOKE GENERATOR
            map.Add(39, "Destroyer/2,3,4,5,6,7,8,9,10/uk/a");
            // SMOKE
            map.Add(40, "Destroyer/2,3,4,5,6,7,8,9,10/pan_asia/a");
            map.Add(41, "Destroyer/2/germany/a");
            map.Add(42, "Destroyer/3/germany/a");
            map.Add(43, "Destroyer/4/germany/a");
            map.Add(44, "Destroyer/5/germany/a");
            map.Add(45, "Destroyer/6/germany/a");
            map.Add(46, "Destroyer/7/germany/a");
            map.Add(47, "Destroyer/8/germany/a");
            map.Add(48, "Destroyer/9/germany/a");
            map.Add(49, "Destroyer/10/germany/a");
            map.Add(50, "Destroyer/2/japan,ussr/a");
            map.Add(51, "Destroyer/3/japan,ussr/a");
            map.Add(52, "Destroyer/4/japan,ussr/a");
            map.Add(53, "Destroyer/5/japan,ussr/a");
            map.Add(54, "Destroyer/6/japan,ussr/a");
            map.Add(55, "Destroyer/7/japan,ussr/a");
            map.Add(56, "Destroyer/8/japan,ussr/a");
            map.Add(57, "Destroyer/9/japan,ussr/a");
            map.Add(58, "Destroyer/10/japan,ussr/a");
            // EXHAUST SMOKE
            map.Add(59, "Cruiser/5,6/italy/a");
            map.Add(60, "Cruiser/7,8,9,10/italy/a");
            // SPEED BOOST
            map.Add(61, "Battleshp/8,9,10/france/a");
            map.Add(62, "Cruiser/6,7/france/a");
            map.Add(63, "Cruiser/8,9,10/france/a");
            map.Add(64, "Destroyer/2,3,4,5,6,7,8,9,10/japan,usa,ussr,germany,pan_asia,commonwealth,europe/a");
            map.Add(65, "Destroyer/2,3,4,5,6,7/france/a");
            map.Add(66, "Destroyer/8,9,10/france/a");
            // MAIN BATTERY RELOAD BOOSTER
            map.Add(67, "Destroyer/6,7,8,9,10/france/a");
            map.Add(68, "Cruiser/6,7,8/france/a");
            map.Add(69, "Cruiser/9,10/france/a");
            // DEF AA
            map.Add(70, "Cruiser/6,7,8,9,10/usa/a");
            map.Add(71, "Cruiser/6,7,8,9,10/japan,germany,france/a");
            map.Add(72, "Cruiser/6,7,8,9,10/ussr/a");
            map.Add(73, "Destroyer/5,6,7,8,9,10/usa/t");
            map.Add(74, "Destroyer/8,9,10/europe/a");
            // CAP FIGHTERS
            map.Add(76, "AirCarrier/4,6,8,10/usa,japan,germany,uk/a");
            // ENGINE COOLING
            map.Add(77, "AirCarrier/4/usa,japan,uk/a");
            map.Add(78, "AirCarrier/4,6,8,10/germany/t");
            map.Add(79, "AirCarrier/6,8,10/usa,japan,uk/a");
            // PATROL FIGHTER
            map.Add(80, "AirCarrier/10/usa,japan,germany,uk/a");
            map.Add(81, "AirCarrier/8/usa,japan,germany,uk/a");
            map.Add(82, "AirCarrier/6/usa,japan,germany,uk/a");
            // AIRCRAFT REPAIR
            map.Add(83, "AirCarrier/8,10/usa,japan,germany,uk/a");

            if ( map.ContainsKey(groupId))
            {
                return map[groupId];
            }
            return "";
        }
    }
}
