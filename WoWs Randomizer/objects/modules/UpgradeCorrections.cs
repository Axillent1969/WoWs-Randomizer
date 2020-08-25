using System;
using System.Collections.Generic;
using WoWs_Randomizer.objects.ship;
using WoWs_Randomizer.utils;

namespace WoWs_Randomizer.objects.modules
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
            //Slot5Upgrades.Add(4238528432); // This upgrade will be moved to slot 6 in patch 0.9.5
            Slot5Upgrades.Add(4244819888);
            Slot5Upgrades.Add(4249014192);
            Slot5Upgrades.Add(4235382704);
            //Slot5Upgrades.Add(4239577008); // This will happen in patch 0.9.5: CHANGE REVOKED

            List<long> Slot6Upgrades = new List<long>();
            Slot6Upgrades.Add(4237479856);
            Slot6Upgrades.Add(4234334128);
            Slot6Upgrades.Add(4245868464);
            Slot6Upgrades.Add(4247965616);
            Slot6Upgrades.Add(4246917040);
            Slot6Upgrades.Add(4243771312);
            Slot6Upgrades.Add(4239577008); // This upgrade will move to slot 5 in patch 0.9.5: CHANGE REVOKED
            Slot6Upgrades.Add(4231188400);
            Slot6Upgrades.Add(4230139824);
            Slot6Upgrades.Add(4229091248);
            Slot6Upgrades.Add(4238528432); //This will happen in patch 0.9.5

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

        private bool canEquipSmokeGeneratorMod1()
        {
            // Has Smoke Generator and therefore can equip Smoke Generator Mod 1
            List<long> canEquip = new List<long>();
            canEquip.Add(3760076080);
            canEquip.Add(3764270928);
            canEquip.Add(3769513264);
            canEquip.Add(4180588496);
            canEquip.Add(4183734224);
            canEquip.Add(3762206160);
            canEquip.Add(4181637072);
            canEquip.Add(3655251408);
            canEquip.Add(4179539920);
            canEquip.Add(4182685648);
            canEquip.Add(3763255248);
            canEquip.Add(3553540080);

            if (canEquip.Contains(selectedShip.ID))
            {
                return true;
            }
            else if (selectedShip.ShipType.Equals(ShipTypes.DD.ToString()))
            {
                if (selectedShip.Country.Equals(Countries.PAA.ToString()) || selectedShip.Country.Equals(Countries.UK.ToString()) || selectedShip.Country.Equals(Countries.USA.ToString()) || selectedShip.Country.Equals(Countries.GER.ToString()) || selectedShip.Country.Equals(Countries.JPN.ToString()) || selectedShip.Country.Equals(Countries.USSR.ToString()))
                {
                    return true;
                }
            }
            return false;
        }

        private bool canEquipSRM1()
        {
            // Has Radar and therefore can equip Surveillance Radar Modification 1
            if (selectedShip.Tier >= 9)
            {
                List<long> canEquipSRM = new List<long>();
                canEquipSRM.Add(3551410160);
                canEquipSRM.Add(4180588528);
                canEquipSRM.Add(3761190896);
                canEquipSRM.Add(3760109552);
                canEquipSRM.Add(3666786288);
                canEquipSRM.Add(4180554960);
                canEquipSRM.Add(4180587984);
                canEquipSRM.Add(3761157584);
                canEquipSRM.Add(4180588496);
                canEquipSRM.Add(4075730928);

                canEquipSRM.Add(4179539920);
                canEquipSRM.Add(4273911792);
                canEquipSRM.Add(4179539408);
                canEquipSRM.Add(3655251952);
                canEquipSRM.Add(3550394352);
                canEquipSRM.Add(3655218480);
                canEquipSRM.Add(3760109008);
                canEquipSRM.Add(4074682352);
                canEquipSRM.Add(4179506384);

                if (canEquipSRM.Contains(selectedShip.ID))
                {
                    return true;
                }
            }
            return false;
        }

        private bool canEquipHydroMod1()
        {
            // Has Hydro and therefore can equip Hydroacoustic Search Mod 1
            if (selectedShip.ID == 3742316496 || selectedShip.ID == 3764303600 || selectedShip.ID == 3763255024 || selectedShip.ID == 3658397424 || selectedShip.ID == 3763221872 || selectedShip.ID == 3762173136 || selectedShip.ID == 4076745936 || selectedShip.ID == 3760076080)
            {
                return true;
            }
            else if (selectedShip.Country.Equals(Countries.GER.ToString()))
            {
                return true;
            }
            else if (selectedShip.ShipType.Equals(ShipTypes.CA.ToString()) && !selectedShip.Country.Equals(Countries.ITA.ToString()))
            {
                return true;
            }
            else if (selectedShip.Country.Equals(Countries.UK.ToString()) && selectedShip.ShipType.Equals(ShipTypes.DD.ToString()))
            {
                return true;
            }
            return false;
        }

        private bool canEquipDefAAMod1()
        {
            // Has Defensive AA and therefore can equip the Defensive AA Fire Mod 1
            if (selectedShip.Tier >= 8)
            {
                if (selectedShip.Country.Equals(Countries.UK.ToString()) && selectedShip.ShipType.Equals(ShipTypes.CA.ToString()))
                {
                    // Only heavy cruisers...
                    if (selectedShip.ID == 4076779472 || selectedShip.ID == 4075730896 || selectedShip.ID == 4074682320 || selectedShip.ID == 3762206672)
                    {
                        return true;
                    }
                }
                else if (selectedShip.ID == 3751720144 || selectedShip.ID == 3762173136 || selectedShip.ID == 4076746192 || selectedShip.ID == 4182652368 || selectedShip.ID == 4074649040 || selectedShip.ID == 4074649424)
                {
                    return true;
                }
                else if (selectedShip.Country.Equals(Countries.USA.ToString()) && selectedShip.ShipType.Equals(ShipTypes.DD.ToString()))
                {
                    return true;
                }
                else if (selectedShip.ShipType.Equals(ShipTypes.CA.ToString()))
                {
                    if (selectedShip.Country.Equals(Countries.USA.ToString()) || selectedShip.Country.Equals(Countries.JPN.ToString()) || selectedShip.Country.Equals(Countries.GER.ToString()) || selectedShip.Country.Equals(Countries.FRA.ToString()) || selectedShip.Country.Equals(Countries.USSR.ToString()))
                    {
                        return true;
                    }
                }
                else if (selectedShip.Country.Equals(Countries.EUR.ToString()) && selectedShip.ShipType.Equals(ShipTypes.DD.ToString()))
                {
                    return true;
                }
            }
            return false;
        }

        private bool canEquipEngineBoostMod1()
        {
            // Has engine boost and therefore can equip the Engine Boost Mod 1
            if (selectedShip.ID == 3764271056 || selectedShip.ID == 3752736720 || selectedShip.ID == 3764270928 || selectedShip.ID == 3762173776 || selectedShip.ID == 3530504176)
            {
                return true;
            }
            
            else if (selectedShip.Country.Equals(Countries.FRA.ToString()))
            {
                return true;
            } 

            else if (selectedShip.Country.Equals(Countries.EUR.ToString()) || selectedShip.Country.Equals(Countries.JPN.ToString()) || selectedShip.Country.Equals(Countries.USA.ToString()) || selectedShip.Country.Equals(Countries.USSR.ToString()) || selectedShip.Country.Equals(Countries.GER.ToString()) || selectedShip.Country.Equals(Countries.CW.ToString()) || selectedShip.Country.Equals(Countries.PAA.ToString()))
            {
                if (selectedShip.ShipType.Equals(ShipTypes.DD.ToString()) && selectedShip.ID != 3760076080)
                {
                    return true;
                }
            }
            return false;
        }

        private bool canEquipSpottingAircraftMod1()
        {
            // Has Spotting aircraft consumable - can equip Spotting Aircraft Modification 1
            if (selectedShip.Country.Equals(Countries.USA.ToString()) && selectedShip.ShipType.Equals(ShipTypes.BB.ToString()) && selectedShip.ID != 3761190896)
            {
                return true;
            }
            else if (selectedShip.Country.Equals(Countries.USA.ToString()) && selectedShip.ShipType.Equals(ShipTypes.CA.ToString()))
            {
                if (selectedShip.ID == 4076779504 || selectedShip.ID == 4180588528 || selectedShip.ID == 4273911792 || selectedShip.ID == 3762206704 || selectedShip.ID == 3542005744 || selectedShip.ID == 3666786288 || selectedShip.ID == 3760109552 || selectedShip.ID == 3655251952)
                {
                    return true;
                }
            }
            else if (selectedShip.Country.Equals(Countries.JPN.ToString()) && selectedShip.ShipType.Equals(ShipTypes.BB.ToString()))
            {
                if (selectedShip.ID != 4286527184 && selectedShip.ID != 3763287760)
                {
                    return true;
                }
            }
            else if (selectedShip.Country.Equals(Countries.USSR.ToString()) && selectedShip.ShipType.Equals(ShipTypes.CA.ToString()) && (selectedShip.Tier == 6 || selectedShip.Tier == 7))
            {
                return true;
            }
            else if (selectedShip.Country.Equals(Countries.GER.ToString()) && selectedShip.ID != 3764336432)
            {
                return true;
            }
            else if ((selectedShip.Country.Equals(Countries.UK.ToString()) && selectedShip.ShipType.Equals(ShipTypes.BB.ToString())) || selectedShip.ID == 4292818896)
            {
                return true;
            }
            else if (selectedShip.Country.Equals(Countries.UK.ToString()) && selectedShip.ShipType.Equals(ShipTypes.CA.ToString()))
            {
                if (selectedShip.ID == 4184782800 || selectedShip.ID == 4183734224 || selectedShip.ID == 4181637072 || selectedShip.ID == 4182685648 || selectedShip.ID == 4077828048 || selectedShip.ID == 4076779472)
                {
                    return true;
                }
            }
            else if (selectedShip.Country.Equals(Countries.ITA.ToString()) && selectedShip.ShipType.Equals(ShipTypes.CA.ToString()))
            {
                return true;
            }
            else
            {
                List<long> specific = new List<long>();
                specific.Add(3760109264);
                specific.Add(3749623504);
                specific.Add(4282300112);
                specific.Add(4259231440);
                specific.Add(3315513040);
                specific.Add(4180588336);
                specific.Add(3340678960);
                specific.Add(4179539760);
                specific.Add(4180588368);
                specific.Add(3764303216);
                specific.Add(4291737040);
                specific.Add(3761157584);
                specific.Add(3751720144);
                specific.Add(3762239216);
                specific.Add(3762239312);
                specific.Add(4181669712);
                specific.Add(3761190096);
                specific.Add(3760109264);
                if (specific.Contains(selectedShip.ID))
                {
                    return true;
                }
            }
            return false;
        }

        private void CVCorrections()
        {
            if (selectedShip.ShipType.Equals(ShipTypes.CV.ToString()))
            {
                corrections.Add(4223848368);
                corrections.Add(4226994096);
                corrections.Add(4224896944);
                corrections.Add(4219654064);
                corrections.Add(4229091248);
            }
        }
    }
}
