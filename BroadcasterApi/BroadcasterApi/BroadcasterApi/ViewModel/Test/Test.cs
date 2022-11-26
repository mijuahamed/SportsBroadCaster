using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BroadcasterApi.ViewModel.Test
{
    public class Test
    {
        [JsonProperty("embed")]
        public string embed { get; set; }

    }
}
