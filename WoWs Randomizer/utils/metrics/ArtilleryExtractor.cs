using System;
using WoWs_Randomizer.utils.module;
using WoWs_Randomizer.utils.ship;

namespace WoWs_Randomizer.utils.metrics
{
    class ArtilleryExtractor
    {
        private ModuleData module = null;
        private Ship selectedShip = null;
        private double rotationTime = 0;
        private double fireRate = 0;
        private long apDamage = 0;
        private long heDamage = 0;
        private long gunCaliber = 0;
        private double dispersion = 0;
        private string name = "";
        private long credit = 0;
        private long id = 0;

        public ArtilleryExtractor(ModuleData module, Ship selectedShip)
        {
            if ( module == null || selectedShip == null) { throw new Exception("Module can not be null"); }
            this.module = module;
            this.selectedShip = selectedShip;
            extract();
        }

        public String Name() { return name; }
        public double RotationTime() { return rotationTime; }
        public double FireRate() { return fireRate; }
        public long APDamage() { return apDamage; }
        public long HEDamage() { return heDamage; }
        public long GunCaliber() { return gunCaliber; }
        public double Dispersion() { return dispersion; }
        public long ID() { return id; }
        public long CreditCost() { return credit; }

        private void extract()
        {

            if (module.Artillery != null)
            {
                rotationTime = module.Artillery.RotationTime;
                fireRate = module.Artillery.GunRate;
                apDamage = module.Artillery.APDamage;
                heDamage = module.Artillery.HEDamage;
            }
            else
            {
                rotationTime = double.Parse(module.Profile["artillery"]["rotation_time"].ToString());
                fireRate = double.Parse(module.Profile["artillery"]["gun_rate"].ToString());
                if (module.Profile["artillery"]["max_damage_AP"] != null)
                {
                    apDamage = long.Parse(module.Profile["artillery"]["max_damage_AP"].ToString());
                }
                if (module.Profile["artillery"]["max_damage_HE"] != null)
                {
                    heDamage = long.Parse(module.Profile["artillery"]["max_damage_HE"].ToString());
                }
            }
            name = module.Name;
            if (name.Contains(" mm/") || name.Contains(" mm "))
            {
                string caliber = name.Substring(0, name.IndexOf(" "));
                gunCaliber = long.Parse(caliber);
            }
            if (selectedShip.Profile.Artillery != null && selectedShip.Profile.Artillery.Dispersion != 0)
            {
                dispersion = selectedShip.Profile.Artillery.Dispersion;
            }
            credit = module.PriceCredits;
            id = module.ID;
        }
    }
}
