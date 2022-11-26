using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ResponseModel.User
{
    public class List_of_User_ResponseModel
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("error")]
        public string Error { get; set; }
        [JsonProperty("data")]
        public List<UserObject> Users { set; get; }

    }
}
public class UserObject
{
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("UserName")]
    public string UserName { get; set; }
    [JsonProperty("email")]
    public string Email { get; set; }
    [JsonProperty("address")]
    public string Address { get; set; }
    [JsonProperty("phoneNumber")]
    public string PhoneNumber { get; set; }
    [JsonProperty("age")]
    public int Age { get; set; }
    [JsonProperty("isActive")]
    public bool IsActive { get; set; }
}