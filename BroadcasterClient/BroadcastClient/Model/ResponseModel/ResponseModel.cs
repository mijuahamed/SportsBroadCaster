using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ResponseModel
{
    public class ResponseModel
    {
        [JsonProperty("success")]
        public bool Success { set; get; }
        [JsonProperty("message")]
        public string Message { set; get; }
        [JsonProperty("data")]
        public Data data { get; set; }
    }
}
public class Data
{
    public bool succeeded { get; set; }
    public List<object> errors { get; set; }
}
