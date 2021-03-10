using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using WoWs_Randomizer.objects;

namespace WoWs_Randomizer.utils
{
    static class Commons
    {
        public static string GetCurrentDirectory()
        {
            string AssemblyLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
            return System.IO.Path.GetDirectoryName(AssemblyLocation);
        }

        public static string GetLogFileName(string suffix = "obj")
        {
            string CurrentDirectory = GetCurrentDirectory();
            string FileName = CurrentDirectory + @"\log." + suffix;
            return FileName;
        }

        public static string GetFlagsFileName()
        {
            string CurrentDirectory = GetCurrentDirectory();
            string FileName = CurrentDirectory + @"\flags.obj";
            return FileName;
        }

        public static string GetUpgradesFileName()
        {
            string CurrentDirectory = GetCurrentDirectory();
            string FileName = CurrentDirectory + @"\upgrades.obj";
            return FileName;
        }

        public static string GetCommanderSkillFileName()
        {
            string CurrentDirectory = GetCurrentDirectory();
            string FileName = CurrentDirectory + @"\skills.obj";
            return FileName;
        }

        public static string GetSettingsFileName()
        {
            string CurrentDirectory = GetCurrentDirectory();
            string FileName = CurrentDirectory + @"\settings.cfg";
            return FileName;
        }

        public static string GetExclusionListFileName()
        {
            string CurrentDirectory = GetCurrentDirectory();
            string FileName = CurrentDirectory + @"\exclusionlist.obj";
            return FileName;
        }

        public static string GetModulesFileName()
        {
            string CurrentDirectory = GetCurrentDirectory();
            return CurrentDirectory + @"\modules.obj";
        }

        public static string GetShipListFileName()
        {
            string CurrentDirectory = GetCurrentDirectory();
            return CurrentDirectory + @"\shiplist.obj";
        }

        public static string GetPersonalShipsFileName()
        {
            string CurrentDirectory = GetCurrentDirectory();
            return CurrentDirectory + @"\myships.obj";
        }

        public static Settings GetSettings()
        {
            string FileName = Commons.GetSettingsFileName();

            if (File.Exists(FileName))
            {
                Settings settings = BinarySerialize.ReadFromBinaryFile<Settings>(FileName);
                return settings;
            }
            return null;
        }

        public static void SaveSettings(Settings MySettings)
        {
            string FileName = Commons.GetSettingsFileName();
            BinarySerialize.WriteToBinaryFile<Settings>(FileName, MySettings);
        }

        public static bool IsNumeric(string test)
        {
            return int.TryParse(test, out _);
        }

        public static DateTime ConvertToDate(long unixdate)
        {
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime GameDate = start.AddSeconds(unixdate).ToLocalTime();
            return GameDate;
        }

        public static string ConvertDateToLocalFormat(DateTime date, string locale)
        {
            CultureInfo culture = new CultureInfo(locale);
            return date.ToString("G", culture);
        }

        public static string GetFlagURL(string Country)
        {
            Dictionary<string, string> Flags = new Dictionary<string, string>
            {
                { "japan", "https://wiki.gcdn.co/images/5/5b/Wows_flag_Japan.png" },
                { "usa", "https://wiki.gcdn.co/images/f/f2/Wows_flag_USA.png" },
                { "ussr", "https://wiki.gcdn.co/images/0/04/Wows_flag_Russian_Empire_and_USSR.png" },
                { "germany", "https://wiki.gcdn.co/images/6/6b/Wows_flag_Germany.png" },
                { "uk", "https://wiki.gcdn.co/images/3/34/Wows_flag_UK.png" },
                { "commonwealth", "https://wiki.gcdn.co/images/9/9a/Wows_flag_Commonwealth.png" },
                { "france", "https://wiki.gcdn.co/images/7/71/Wows_flag_France.png" },
                { "italy", "https://wiki.gcdn.co/images/d/d1/Wows_flag_Italy.png" },
                { "pan_asia", "https://wiki.gcdn.co/images/3/33/Wows_flag_Pan_Asia.png" },
                { "pan_america", "https://wiki.gcdn.co/images/9/9e/Wows_flag_Pan_America.png" },
                { "europe", "https://wiki.gcdn.co/images/5/52/Wows_flag_Europe.png" }
            };

            return Flags[Country.ToLower()];
        }

        public static string TranslateTrueFalse(bool state)
        {
            return ((state) ? "Yes" : "No");
        }
    }
}
