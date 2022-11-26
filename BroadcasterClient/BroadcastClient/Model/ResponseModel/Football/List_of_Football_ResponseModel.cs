using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ResponseModel.Football
{
    public class List_of_Football_ResponseModel
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("error")]
        public string Error { get; set; }
        [JsonProperty("data")]
        public List<FootballObject> data { set; get; }

    }
}
public class FootballObject
{
    [JsonProperty("title")]
    public string title { get; set; }
    [JsonProperty("embed")]
    public string embed { get; set; }
    [JsonProperty("date")]
    public string date { get; set; }

    [JsonProperty("competition")]
    public Competition Competition { set; get; }
}
   
public class Competition
{
    [JsonProperty("name")]
    public string Name { set; get; }
}