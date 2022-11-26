using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.RequestModel
{
    public class RegistrationRequestModel
    {
        [JsonProperty("userName")]
        public string UserName { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("age")]
        public int Age { get; set; }
        [JsonProperty("phoneNumber")]
        public string Phone { get; set; }
        [JsonProperty("password")]
        public string Password { set; get; }
        
    }
}
