using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ResponseModel.Menu
{
    public class MenuPermissionByUserIdResponseModel
    {
       [JsonProperty("success")]
       public bool Success { set; get; }
       [JsonProperty("message")]
       public string Message { set; get; }
       [JsonProperty("error")]
       public string Error { set; get; }
       [JsonProperty("data")]
       public List<MenuPermitList> Data { set; get; }
    }
}
public class MenuPermitList
{
    [JsonProperty("id")]
    public int Id { set; get; }
    [JsonProperty("parentId")]
    public int ParentId { set; get; }
    [JsonProperty("name")]
    public string Name { set; get; }
}