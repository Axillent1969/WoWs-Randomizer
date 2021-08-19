using System;

namespace WoWs_Randomizer.utils
{
    public class Countries : Enumeration
    {
        public static readonly Countries GER = new Countries("germany", "Germany","de");
        public static readonly Countries PAA = new Countries("pan_asia", "Pan-Asia","pa");
        public static readonly Countries UK = new Countries("uk", "U.K.","gb");
        public static readonly Countries USA = new Countries("usa", "U.S.A.","us");
        public static readonly Countries JPN = new Countries("japan", "Japan","jp");
        public static readonly Countries USSR = new Countries("ussr", "U.S.S.R.","ru");
        public static readonly Countries FRA = new Countries("france", "France","fr");
        public static readonly Countries ITA = new Countries("italy", "Italy","it");
        public static readonly Countries CW = new Countries("commonwealth", "Commonwealth","cw");
        public static readonly Countries EUR = new Countries("europe", "Europe","eu");
        public static readonly Countries PAM = new Countries("pan_america", "Pan-America","pm");
        public static readonly Countries NL = new Countries("netherlands", "Netherlands","nl");

        public Countries(string abbreviation, string name,string code) : base(abbreviation,name,code)
        {
        }
    }
}
