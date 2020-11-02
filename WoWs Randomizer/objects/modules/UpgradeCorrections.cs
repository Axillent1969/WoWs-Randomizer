using System;
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

        private void populateLegendaryList()
        {
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

        public bool canEquipSmokeGeneratorMod1()
        {
            return (selectedShip.GetConsumableInfo(ConsumableType.Smoke) != null);
        }

        public bool canEquipSRM1()
        {
            return (selectedShip.GetConsumableInfo(ConsumableType.Radar) != null);
        }

        public bool canEquipHydroMod1()
        {
            return (selectedShip.GetConsumableInfo(ConsumableType.Hydro) != null);
        }

        public bool canEquipDefAAMod1()
        {
            return (selectedShip.GetConsumableInfo(ConsumableType.DefAA) != null);
        }

        public bool canEquipEngineBoostMod1()
        {
            return (selectedShip.GetConsumableInfo(ConsumableType.SpeedBoost) != null);

        }

        public bool canEquipEmergencyEnginePower()
        {
            return (selectedShip.GetConsumableInfo(ConsumableType.EmergencyEnginePower) != null);
        }

        public bool canEquipSpottingAircraftMod1()
        {
            return (selectedShip.GetConsumableInfo(ConsumableType.SpotterPlane) != null);
        }

        private void CVCorrections()
        {
            if (selectedShip.ShipType.ToLower().Equals(ShipTypes.CV.ToString()))
            {
                corrections.Add(4223848368);
                corrections.Add(4226994096);
                corrections.Add(4224896944);
                corrections.Add(4219654064);
            }
        }
    }
}
