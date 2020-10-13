using System.Collections.Generic;
using WoWs_Randomizer.objects.consumables;

namespace WoWs_Randomizer.utils.specialFlags
{
    public class Flags
    {
        public static Consumable DragonFlag()
        {
            Consumable flag = new Consumable();
            flag.ID = 9999999001;
            flag.Name = "Dragon";
            flag.Description = "\"Naval Elite\"";

            Dictionary<string, ConsumableProfile> CProfile = new Dictionary<string, ConsumableProfile>();

            ConsumableProfile profile = new ConsumableProfile();
            profile.Description = "+333% Commander XP earned for the battle.";
            profile.Value = 333;
            CProfile.Add("0", profile);

            flag.Profile = CProfile;
            return flag;
        }

        public static Consumable Wyvern()
        {
            Consumable flag = new Consumable();
            flag.ID = 9999999002;
            flag.Name = "Wyvern";
            flag.Description = "";

            Dictionary<string, ConsumableProfile> CProfile = new Dictionary<string, ConsumableProfile>();

            ConsumableProfile profile = new ConsumableProfile();
            profile.Description = "+50% credits earned for the battle.";
            profile.Value = 50;
            CProfile.Add("0", profile);

            flag.Profile = CProfile;
            return flag;
        }

        public static Consumable RedDragon()
        {
            Consumable flag = new Consumable();
            flag.ID = 9999999003;
            flag.Name = "Red Dragon";
            flag.Description = "";

            Dictionary<string, ConsumableProfile> CProfile = new Dictionary<string, ConsumableProfile>();

            ConsumableProfile profile = new ConsumableProfile();
            profile.Description = "+100% XP earned for the battle.";
            profile.Value = 100;
            CProfile.Add("0", profile);

            ConsumableProfile profile2 = new ConsumableProfile();
            profile2.Description = "+100% Commander XP earned for the battle.";
            profile2.Value = 100;
            CProfile.Add("1", profile2);

            flag.Profile = CProfile;
            return flag;
        }

        public static Consumable Ouroboros()
        {
            Consumable flag = new Consumable();
            flag.ID = 9999999004;
            flag.Name = "Ouroboros";
            flag.Description = "";

            Dictionary<string, ConsumableProfile> CProfile = new Dictionary<string, ConsumableProfile>();

            ConsumableProfile profile = new ConsumableProfile();
            profile.Description = "+777% Free XP earned for the battle.";
            profile.Value = 777;
            CProfile.Add("0", profile);

            flag.Profile = CProfile;
            return flag;
        }

        public static Consumable Hydra()
        {
            Consumable flag = new Consumable();
            flag.ID = 9999999005;
            flag.Name = "Hydra";
            flag.Description = "";

            Dictionary<string, ConsumableProfile> CProfile = new Dictionary<string, ConsumableProfile>();

            ConsumableProfile profile = new ConsumableProfile();
            profile.Description = "+50% XP earned for the battle.";
            profile.Value = 50;
            CProfile.Add("0", profile);

            ConsumableProfile profile2 = new ConsumableProfile();
            profile2.Description = "+150% Commander XP earned for the battle.";
            profile2.Value = 150;
            CProfile.Add("1", profile2);

            ConsumableProfile profile3 = new ConsumableProfile();
            profile3.Description = "+250% Free XP earned for the battle.";
            profile3.Value = 250;
            CProfile.Add("2", profile3);

            flag.Profile = CProfile;
            return flag;
        }

        public static Consumable Basilisk()
        {
            Consumable flag = new Consumable();
            flag.ID = 9999999006;
            flag.Name = "Basilisk";
            flag.Description = "";

            Dictionary<string, ConsumableProfile> CProfile = new Dictionary<string, ConsumableProfile>();

            ConsumableProfile profile = new ConsumableProfile();
            profile.Description = "+75% XP earned for the battle.";
            profile.Value = 75;
            CProfile.Add("0", profile);

            ConsumableProfile profile2 = new ConsumableProfile();
            profile2.Description = "+50% credits earned for the battle.";
            profile2.Value = 50;
            CProfile.Add("1", profile2);

            flag.Profile = CProfile;
            return flag;
        }

        public static Consumable Scylla()
        {
            Consumable flag = new Consumable();
            flag.ID = 9999999007;
            flag.Name = "Scylla";
            flag.Description = "";

            Dictionary<string, ConsumableProfile> CProfile = new Dictionary<string, ConsumableProfile>();

            ConsumableProfile profile = new ConsumableProfile();
            profile.Description = "+50% XP earned for the battle.";
            profile.Value = 50;
            CProfile.Add("0", profile);

            ConsumableProfile profile2 = new ConsumableProfile();
            profile2.Description = "+150% Commander XP earned for the battle.";
            profile2.Value = 150;
            CProfile.Add("1", profile2);

            ConsumableProfile profile3 = new ConsumableProfile();
            profile3.Description = "+25% credits earned for the battle.";
            profile3.Value = 25;
            CProfile.Add("2", profile3);

            flag.Profile = CProfile;
            return flag;
        }

        public static Consumable Leviathan()
        {
            Consumable flag = new Consumable();
            flag.ID = 9999999008;
            flag.Name = "Leviathan";
            flag.Description = "";

            Dictionary<string, ConsumableProfile> CProfile = new Dictionary<string, ConsumableProfile>();

            ConsumableProfile profile = new ConsumableProfile();
            profile.Description = "+50% XP earned for the battle.";
            profile.Value = 50;
            CProfile.Add("0", profile);

            ConsumableProfile profile2 = new ConsumableProfile();
            profile2.Description = "+100% Commander XP earned for the battle.";
            profile2.Value = 100;
            CProfile.Add("1", profile2);

            ConsumableProfile profile3 = new ConsumableProfile();
            profile3.Description = "+200% Free XP earned for the battle.";
            profile3.Value = 200;
            CProfile.Add("2", profile3);

            ConsumableProfile profile4 = new ConsumableProfile();
            profile4.Description = "+20% credits earned for the battle.";
            profile4.Value = 20;
            CProfile.Add("3", profile3);

            flag.Profile = CProfile;
            return flag;
        }
    }
}
