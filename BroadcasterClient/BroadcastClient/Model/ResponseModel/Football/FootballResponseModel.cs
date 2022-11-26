using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ResponseModel.Football
{
    public class FootballResponseModel
    {
        [JsonProperty("embed")]
        public string embed { get; set; }
    }
}
