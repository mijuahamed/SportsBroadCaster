using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.RequestModel.Menu
{
    public class CreateMenuRequestModel
    {
        [JsonProperty("rootId")]
        public int RootId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("type")]
        public int Type { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
