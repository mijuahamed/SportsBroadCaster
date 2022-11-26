using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ResponseModel
{
    public class List_of_Role_ResponseModel
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }  
        [JsonProperty("error")]
        public string Error { get; set; }
        [JsonProperty("data")]
        public List<RoleObject> Roles { set; get; }

    }
}
public class RoleObject
{
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("normalizedName")]
    public string NormalizedName { get; set; }
    [JsonProperty("concurrencyStamp")]
    public string ConcurrencyStamp { get; set; }
}