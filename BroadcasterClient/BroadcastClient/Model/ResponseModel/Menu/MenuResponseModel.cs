using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ResponseModel.Menu
{
    public class MenuResponseModel
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("error")]
        public string Error { get; set; }
        [JsonProperty("result")]
        public List<MenuObject> Menus { set; get; }

    }
}
public class MenuObject
{
    [JsonProperty("id")]
    public int Id { set; get; }
    [JsonProperty("rootId")]
    public int RootId { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("type")]
    public int Type { get; set; }
    [JsonProperty("url")]
    public string Url { get; set; }

}
