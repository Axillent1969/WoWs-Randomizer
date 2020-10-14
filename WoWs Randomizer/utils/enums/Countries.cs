using System;

namespace WoWs_Randomizer.utils
{
    public class Countries : Enumeration
    {
        public static readonly Countries GER = new Countries("germany", "Germany");
        public static readonly Countries PAA = new Countries("pan_asia", "Pan-Asia");
        public static readonly Countries UK = new Countries("uk", "U.K.");
        public static readonly Countries USA = new Countries("usa", "U.S.A.");
        public static readonly Countries JPN = new Countries("japan", "Japan");
        public static readonly Countries USSR = new Countries("ussr", "U.S.S.R.");
        public static readonly Countries FRA = new Countries("france", "France");
        public static readonly Countries ITA = new Countries("italy", "Italy");
        public static readonly Countries CW = new Countries("commonwealth", "Commonwealth");
        public static readonly Countries EUR = new Countries("europe", "Europe");
        public static readonly Countries PAM = new Countries("pan_america", "Pan-America");

        public Countries(string abbreviation, string name) : base(abbreviation,name)
        {
        }
    }
}
