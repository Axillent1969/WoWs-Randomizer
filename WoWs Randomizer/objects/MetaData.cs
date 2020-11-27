using System;
using Newtonsoft.Json;

namespace WoWs_Randomizer.utils
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
