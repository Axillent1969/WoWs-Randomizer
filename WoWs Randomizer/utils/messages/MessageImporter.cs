using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WoWs_Randomizer.utils.messages
{
    public class MessageImporter
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("messageid")]
        public string MessageID { get; set; }
        [JsonProperty("datetime")]
        public string StartDate { get; set; }
        [JsonProperty("enddate")]
        public string EndDate { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("link")]
        public String URL { get; set; }
        [JsonProperty("images")]
        public Dictionary<string,string> Images { get; set; }

    }
}
