using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WoWs_Randomizer.objects
{
    [Serializable]
    public class MetaData
    {
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("page_total")]
        public int Pages { get; set; }
        [JsonProperty("total")]
        public int Total { get; set; }
        [JsonProperty("limit")]
        public int Limit { get; set; }
        [JsonProperty("page")]
        public int PageNumber { get; set; }
    }
}
