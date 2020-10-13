using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoWs_Randomizer.utils.module;

namespace WoWs_Randomizer.utils.metrics
{
    class TorpedoExtractor
    {
        private ModuleData module = null;

        public TorpedoExtractor(ModuleData module)
        {
            if (module == null) { throw new Exception("Nullpointer... Module can not be null"); }
            this.module = module;
            calculate();
        }

        public double Speed { get; set; }
        public double Distance { get; set; }
        public double Damage { get; set; }
        public double TravelSpeed { get; set; }
        public double ReloadTime { get; set; }

        private void calculate()
        {
            if ( module.TorpedoSpeed != 0 )
            {
                this.Distance = module.TorpedoRange;
                this.Damage = module.TorpedoDamage;
                this.TravelSpeed = module.TorpedoSpeed;
                this.Speed = module.TorpedoReload;
            } else
            {
                this.Speed = Double.Parse(module.Profile["torpedoes"]["shot_speed"].ToString());
                this.Distance = Double.Parse(module.Profile["torpedoes"]["distance"].ToString());
                this.Damage = Double.Parse(module.Profile["torpedoes"]["max_damage"].ToString());
                this.TravelSpeed = Double.Parse(module.Profile["torpedoes"]["torpedo_speed"].ToString());
            }
           
            if (module.ID == 3346411216 || module.ID == 3335925456)
            {
                // Correction for torp reload of Shima Type93 mod 3 torps
                // Correction for torp reload of Hayate Type93 mod 3 torps
                this.Speed = 0.39216;
            }

            this.ReloadTime = Math.Round(60 / this.Speed, 0);
        }
    }
}
