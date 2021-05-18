using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using WoWs_Randomizer.utils;
using WoWs_Randomizer.utils.module;
using WoWs_Randomizer.utils.player;
using WoWs_Randomizer.utils.ship;
using WoWs_Randomizer.utils.skills;
using WoWs_Randomizer.utils.version;
using WoWs_Randomizer.objects.consumables;
using WoWs_Randomizer.objects.version;
using WoWs_Randomizer.objects.player;
using WoWs_Randomizer.objects.clan;
using WoWs_Randomizer.utils.messages;

namespace WoWs_Randomizer.api
{
    static class WGAPI
    {
        static readonly string APP_ID = "";
        static HttpClient Client = new HttpClient();

        public static MessageImporter GetMessage()
        {
            using (WebClient wc = new WebClient())
            {
                String jsonFile = Commons.GetCurrentDirectory() + "/message.json";
                wc.DownloadFile("https://onedrive.live.com/download?cid=919CD8D21AC2180D&resid=919CD8D21AC2180D%2117342&authkey=ABLMJUI7LzuHm9o", jsonFile);
                string jsonText = File.ReadAllText(jsonFile);

                MessageImporter Import = null;
                Import = JsonConvert.DeserializeObject<MessageImporter>(jsonText);
                return Import;
            }
        }

        public static ProgramVersion GetProgramVersion()
        {
            using (WebClient wc = new WebClient())
            {
                String jsonFile = Commons.GetCurrentDirectory() + "/randomizer.json";
                wc.DownloadFile("https://onedrive.live.com/download?cid=919CD8D21AC2180D&resid=919CD8D21AC2180D%2116427&authkey=AOg1igxPEZw9EWw", jsonFile);
                string jsonText = File.ReadAllText(jsonFile);

                ProgramVersion Import = null;
                if (IsOldVersion(jsonText))
                {
                    Import = ConvertFromOldVersion(jsonText);
                } else
                {
                    Import = JsonConvert.DeserializeObject<ProgramVersion>(jsonText);
                }
                return Import;
            }
        }

        private static bool IsOldVersion(string jsonText)
        {
            int idx = jsonText.LastIndexOf("changelog");
            string test = jsonText.Substring(idx+16, 1);
            return test.Equals("\"");
        }

        private static ProgramVersion ConvertFromOldVersion(string jsonText)
        {
            ProgramVersion imp = new ProgramVersion();
            ProgramVersionOLD old = JsonConvert.DeserializeObject<ProgramVersionOLD>(jsonText);
            imp.Status = old.Status;
            imp.Version = old.Version;
            imp.Updated = old.Updated;
            imp.URL = old.URL;
            ProgramVersionLog log = new ProgramVersionLog();
            log.Date = old.Updated;
            log.Version = old.Version;
            log.Log = new List<string>();
            log.Log.AddRange(old.ChangeLog);

            imp.ChangeLog = new List<ProgramVersionLog>();
            imp.ChangeLog.Add(log);
            return imp;
        }

        public static ConsumablesInfoImporter GetConsumablesInfo()
        {
            using (WebClient wc = new WebClient())
            {
                string jsonFile = Commons.GetCurrentDirectory() + "/coninfotype.json";
                wc.DownloadFile("https://onedrive.live.com/download?cid=919CD8D21AC2180D&resid=919CD8D21AC2180D%2116820&authkey=AEsjf3lBZE8zABY", jsonFile);
                string jsonText = File.ReadAllText(jsonFile);
                ConsumablesInfoImporter Import = JsonConvert.DeserializeObject<ConsumablesInfoImporter>(jsonText);
                return Import;
            }
        }

        public static ConsumablesImporter GetUpgrades()
        {
            try { Setup(); } catch (Exception) { }
            string path = $"encyclopedia/consumables/?application_id={APP_ID}&type=Modernization";
            var response = Client.GetAsync(path).Result;
            string responseString = "";
            if ( response.IsSuccessStatusCode)
            {
                var responseContent = response.Content;
                responseString = responseContent.ReadAsStringAsync().Result;
            }
            ConsumablesImporter Import = JsonConvert.DeserializeObject<ConsumablesImporter>(responseString);
            return Import;
        }

        public static ConsumablesImporter GetFlags()
        {
            try { Setup(); } catch (Exception) { }
            string path = $"encyclopedia/consumables/?application_id={APP_ID}&type=Flags";
            string responseString = "";
            var response = Client.GetAsync(path).Result;
            if ( response.IsSuccessStatusCode)
            {
                var responseContent = response.Content;
                responseString = responseContent.ReadAsStringAsync().Result;
            }
            ConsumablesImporter Import = JsonConvert.DeserializeObject<ConsumablesImporter>(responseString);
            return Import;
        }

        public static SkillImporter GetCommanderSkills()
        {
            using (WebClient wc = new WebClient())
            {
                string jsonFile = Commons.GetCurrentDirectory() + "/skills.json";
                wc.DownloadFile("https://onedrive.live.com/download?cid=919CD8D21AC2180D&resid=919CD8D21AC2180D%2117153&authkey=AHbaH3E2Ks9MGjM", jsonFile);
                string jsonText = File.ReadAllText(jsonFile);
                SkillImporter Import = JsonConvert.DeserializeObject<SkillImporter>(jsonText);
                return Import;
            }
            /*            try { Setup(); } catch (Exception) { }
                        string path = $"encyclopedia/crewskills/?application_id={APP_ID}";
                        string responseString = "";
                        var response = Client.GetAsync(path).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            var responseContent = response.Content;
                            responseString = responseContent.ReadAsStringAsync().Result;
                        }
                        SkillImporter Importer = JsonConvert.DeserializeObject<SkillImporter>(responseString);
                        return Importer;*/
        }

        public static ShipImporter GetShipData()
        {
            try { Setup(); } catch (Exception) { }
            return GetShipData(1);
        }

        public static List<Ship> GetAllShipsFromWG()
        {
            List<Ship> AllShips = new List<Ship>();
            ShipImporter Importer = WGAPI.GetShipData();
            if (Importer.Status.Equals("ok"))
            {
                int Pages = Importer.MetaInfo.Pages;
                foreach (KeyValuePair<string, Ship> ShipData in Importer.ShipData)
                {
                    AllShips.Add(ShipData.Value);
                }
                if (Pages > 1)
                {
                    for (int Counter = 2; Counter <= Pages; Counter++)
                    {
                        Importer = WGAPI.GetShipData(Counter);
                        if (Importer.Status.Equals("ok"))
                        {
                            foreach (KeyValuePair<string, Ship> ShipData in Importer.ShipData)
                            {
                                AllShips.Add(ShipData.Value);
                            }
                        }
                    }
                }
            }
            return AllShips;
        }

        public static ShipImporter GetShipData(int page)
        {
            try { Setup(); } catch (Exception) { }
            string path = $"encyclopedia/ships/?application_id={APP_ID}&page_no={page}";
            string responseString = "";
            var response = Client.GetAsync(path).Result;
            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content;
                responseString = responseContent.ReadAsStringAsync().Result;
            }
            ShipImporter ImportedShips = JsonConvert.DeserializeObject<ShipImporter>(responseString);
            return ImportedShips;
        }

        public static PlayerSearch SearchPlayer(string PlayerNickname)
        {
            //https://api.worldofwarships.com/wows/account/list/?application_id=1f859aa19885c6a2f61598578621f5e1&search=Axillent
            try { Setup(); } catch (Exception) { }
            string path = $"account/list/?application_id={APP_ID}&search={PlayerNickname}";
            string responseString = "";
            var response = Client.GetAsync(path).Result;
            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content;
                responseString = responseContent.ReadAsStringAsync().Result;
            }
            PlayerSearch result = JsonConvert.DeserializeObject<PlayerSearch>(responseString);
            return result;
        }

        public static PlayerShipImport GetPlayerShips(long ID)
        {
            try { Setup(); } catch (Exception) { }
            string path = $"ships/stats/?application_id={APP_ID}&account_id={ID}&in_garage=1&fields=ship_id";
            string responseString = "";
            var response = Client.GetAsync(path).Result;
            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content;
                responseString = responseContent.ReadAsStringAsync().Result;
            }
            PlayerShipImport PlayerImport = JsonConvert.DeserializeObject<PlayerShipImport>(responseString);
            return PlayerImport;
        }

        public static PlayerPersonalDataImport GetPlayerPersonalData(long ID)
        {
            try { Setup(); } catch(Exception) { }
            string path = $"account/info/?application_id={APP_ID}&account_id={ID}";
            var response = Client.GetAsync(path).Result;
            if ( response.IsSuccessStatusCode )
            {
                var responseContent = response.Content;
                string responseString = responseContent.ReadAsStringAsync().Result;
                PlayerPersonalDataImport Import = JsonConvert.DeserializeObject<PlayerPersonalDataImport>(responseString);
                return Import;
            }
            return null;
        }

        public static PlayerClanInfoImport GetPlayerClanInfo(long ID)
        {
            try { Setup(); } catch (Exception) { }
            string path = $"clans/accountinfo/?application_id={APP_ID}&account_id={ID}&extra=clan";
            var response = Client.GetAsync(path).Result;
            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content;
                string responseString = responseContent.ReadAsStringAsync().Result;
                PlayerClanInfoImport Import = JsonConvert.DeserializeObject<PlayerClanInfoImport>(responseString);
                return Import;
            }
            return null;
        }

        public static ClanImport GetClanInfo(long ClanID)
        {
            try { Setup(); } catch (Exception) { }
            string path = $"clans/info/?application_id={APP_ID}&clan_id={ClanID}&extra=members";
            var response = Client.GetAsync(path).Result;
            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content;
                string responseString = responseContent.ReadAsStringAsync().Result;
                ClanImport Import = JsonConvert.DeserializeObject<ClanImport>(responseString);
                return Import;
            }
            return null;
        }

        public static VersionInfoImport GetVersionInfo()
        {
            try { Setup(); } catch (Exception) { }
            string path = $"encyclopedia/info/?application_id={APP_ID}&fields=ships_updated_at%2Cgame_version";
            string responseString = "";
            var response = Client.GetAsync(path).Result;
            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content;
                responseString = responseContent.ReadAsStringAsync().Result;
            }
            VersionInfoImport Import = JsonConvert.DeserializeObject<VersionInfoImport>(responseString);
            return Import;
        }

        public static ModuleImport GetModules()
        {
            try { Setup(); } catch (Exception) { }
            return GetModules(1);
        }

        public static ModuleImport GetModules(int page)
        {
            try { Setup(); } catch (Exception) { }
            string path = $"encyclopedia/modules/?application_id={APP_ID}&page_no={page}";
            string responseString = "";
            var response = Client.GetAsync(path).Result;
            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content;
                responseString = responseContent.ReadAsStringAsync().Result;
            }
            ModuleImport Import = JsonConvert.DeserializeObject<ModuleImport>(responseString);
            return Import;
        }

        public static Dictionary<string, ModuleData> GetAllModules()
        {
            Dictionary<string, ModuleData> Data = new Dictionary<string, ModuleData>();

            ModuleImport Importer = WGAPI.GetModules();
            if (Importer.Status.Equals("ok"))
            {
                int Pages = Importer.MetaInfo.Pages;
                foreach (KeyValuePair<string, ModuleData> ModData in Importer.Data)
                {
                    Data.Add(ModData.Key, ModData.Value);
                }
                if (Pages > 1)
                {
                    for (int Counter = 2; Counter <= Pages; Counter++)
                    {
                        Importer = WGAPI.GetModules(Counter);
                        if (Importer.Status.Equals("ok"))
                        {
                            foreach (KeyValuePair<string, ModuleData> ModData in Importer.Data)
                            {
                                Data.Add(ModData.Key, ModData.Value);
                            }
                        }
                    }
                }
            }
            return Data;
        }

        public static void OpenShipWikipedia(string shipName)
        {
            if (shipName.Equals(""))
            {
                return;
            }
            else
            {
                string HREF = @"https://wiki.wargaming.net/en/Ship:";   
                System.Diagnostics.Process.Start(HREF + shipName.Replace(' ', '_'));
            }
        }

        private static void Setup()
        {
            Client = new HttpClient();
            if (Program.Settings == null)
            {
                Client.BaseAddress = new Uri("https://api.worldofwarships.eu/wows/");
            }
            else
            {
                string URL = $"https://api.worldofwarships.{Program.Settings.Server}/wows/";
                if (Program.Settings != null && Program.Settings.Server != null && Program.Settings.Server.Equals("NA"))
                {
                    URL = URL.Replace(".NA", ".com");
                }
                Client.BaseAddress = new Uri(URL);
            }
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
