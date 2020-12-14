using System.Collections.Generic;
using WoWs_Randomizer.utils.ship;
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
            addSpecialUpgrades();
            if (Legendary.ContainsKey(selectedShip.ID))
            {
                corrections.Add(Legendary[selectedShip.ID]);
            }
        }

        private void addSpecialUpgrades()
        {
            corrections.Add(4253208496); // Damage Control Party Mod 1. All ships have it but not present in API data.
            if ( selectedShip.canEquipSpottingAircraftMod1())
            {
                corrections.Add(4254257072);
            }
            if ( selectedShip.canEquipEngineBoostMod1() )
            {
                corrections.Add(4256354224);
            }
            if ( selectedShip.canEquipDefAAMod1() )
            {
                corrections.Add(4252159920);
            }
            if ( selectedShip.canEquipHydroMod1() )
            {
                corrections.Add(4251111344);
            }
            if ( selectedShip.canEquipSRM1() )
            {
                corrections.Add(4250062768);
            }
            if ( selectedShip.canEquipSmokeGeneratorMod1() )
            {
                corrections.Add(4255305648);
            }
        }
    }
}
