using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WoWs_Randomizer.objects;
using WoWs_Randomizer.objects.module;
using WoWs_Randomizer.objects.player;
using WoWs_Randomizer.objects.ship;
using WoWs_Randomizer.objects.skills;
using WoWs_Randomizer.objects.upgrades;
using WoWs_Randomizer.objects.version;
using WoWs_Randomizer.utils;

namespace WoWs_Randomizer.api
{
    static class WGAPI
    {
        static readonly string APP_ID = "xxx";
        static HttpClient Client = new HttpClient();

        public static ProgramVersion GetProgramVersion()
        {
            using (WebClient wc = new WebClient())
            {
                String jsonFile = Commons.GetCurrentDirectory() + "/randomizer.json";
                wc.DownloadFile("https://onedrive.live.com/download?cid=919CD8D21AC2180D&resid=919CD8D21AC2180D%2116427&authkey=AOg1igxPEZw9EWw", jsonFile);
                string jsonText = File.ReadAllText(jsonFile);
                ProgramVersion Import = JsonConvert.DeserializeObject<ProgramVersion>(jsonText);
                return Import;
            }
        }

        public static async Task<ConsumablesImporter> GetUpgrades()
        {
            try { Setup(); } catch (Exception) { }
            string path = $"encyclopedia/consumables/?application_id={APP_ID}&type=Modernization";
            HttpResponseMessage response = await Client.GetAsync(path);
            string responseString = await response.Content.ReadAsStringAsync();
            ConsumablesImporter Import = JsonConvert.DeserializeObject<ConsumablesImporter>(responseString);
            return Import;
        }

        public static async Task<ConsumablesImporter> GetFlags()
        {
            try { Setup(); } catch (Exception) { }
            string path = $"encyclopedia/consumables/?application_id={APP_ID}&type=Flags";
            HttpResponseMessage response = await Client.GetAsync(path);
            string responseString = await response.Content.ReadAsStringAsync();
            ConsumablesImporter Import = JsonConvert.DeserializeObject<ConsumablesImporter>(responseString);
            return Import;
        }

        public static async Task<SkillImporter> GetCommanderSkills()
        {
            try { Setup(); } catch (Exception) { }
            string path = $"encyclopedia/crewskills/?application_id={APP_ID}";
            HttpResponseMessage response = await Client.GetAsync(path);
            string responseString = await response.Content.ReadAsStringAsync();
            SkillImporter Importer = JsonConvert.DeserializeObject<SkillImporter>(responseString);
            return Importer;
        }

        public static async Task<ShipImporter> GetShipData()
        {
            try { Setup(); } catch (Exception) { }
            return await GetShipData(1);
        }

        public static async Task<ShipImporter> GetShipData(int page)
        {
            try { Setup(); } catch (Exception) { }
            string path = $"encyclopedia/ships/?application_id={APP_ID}&page_no={page}";
            HttpResponseMessage response = await Client.GetAsync(path);
            string responseString = await response.Content.ReadAsStringAsync();
            ShipImporter ImportedShips = JsonConvert.DeserializeObject<ShipImporter>(responseString);
            return ImportedShips;
        }

        public static async Task<PlayerSearch> SearchPlayer(string PlayerNickname)
        {
            //https://api.worldofwarships.com/wows/account/list/?application_id=1f859aa19885c6a2f61598578621f5e1&search=Axillent
            try { Setup(); } catch (Exception) { }
            string path = $"account/list/?application_id={APP_ID}&search={PlayerNickname}";
            HttpResponseMessage response = await Client.GetAsync(path);
            string responseString = await response.Content.ReadAsStringAsync();
           // Console.WriteLine(responseString);
            PlayerSearch result = JsonConvert.DeserializeObject<PlayerSearch>(responseString);
            return result;
        }

        public static async Task<PlayerShipImport> GetPlayerShips(long ID)
        {
            try { Setup(); } catch (Exception) { }
            string path = $"ships/stats/?application_id={APP_ID}&account_id={ID}&fields=ship_id";
            HttpResponseMessage response = await Client.GetAsync(path);
            string responseString = await response.Content.ReadAsStringAsync();
            //Console.WriteLine(responseString);
            PlayerShipImport PlayerImport = JsonConvert.DeserializeObject<PlayerShipImport>(responseString);
            return PlayerImport;
        }

        public static async Task<VersionInfoImport> GetVersionInfo()
        {
            try { Setup(); } catch (Exception) { }
            string path = $"encyclopedia/info/?application_id={APP_ID}&fields=ships_updated_at%2Cgame_version";
            HttpResponseMessage response = await Client.GetAsync(path);
            string responseString = await response.Content.ReadAsStringAsync();
            //Console.WriteLine(responseString);
            VersionInfoImport Import = JsonConvert.DeserializeObject<VersionInfoImport>(responseString);
            return Import;
        }

        public static async Task<ModuleImport> GetModules()
        {
            try { Setup(); } catch (Exception) { }
            return await GetModules(1);
        }

        public static async Task<ModuleImport> GetModules(int page)
        {
            try { Setup(); } catch (Exception) { }
            string path = $"encyclopedia/modules/?application_id={APP_ID}&page_no={page}";
            HttpResponseMessage response = await Client.GetAsync(path);
            string responseString = await response.Content.ReadAsStringAsync();
            ModuleImport Import = JsonConvert.DeserializeObject<ModuleImport>(responseString);
            return Import;
        }

        private static void Setup()
        {
            Client = new HttpClient();
            Settings MySettings = Commons.GetSettings();
            if (MySettings == null)
            {
                Client.BaseAddress = new Uri("https://api.worldofwarships.eu/wows/");
            }
            else
            {
                string URL = $"https://api.worldofwarships.{MySettings.Server}/wows/";
                if (MySettings.Server.Equals("NA"))
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
