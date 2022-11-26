using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ResponseModel
{
    public class LoginResponseModel
    {
        [JsonProperty("success")]
        public bool Success { set; get; }
        [JsonProperty("message")]
        public string Message { set; get; }
        [JsonProperty("token")]
        public string Token { set; get; }
        [JsonProperty("userId")]
        public string UserId { set; get; }
        [JsonProperty("userRole")]
        public IList<string> UserRole { get; set; }
    }
}
