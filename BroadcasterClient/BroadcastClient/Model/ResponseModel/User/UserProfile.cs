using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ResponseModel.User
{
    public class UserProfile
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
            [JsonProperty("photo")]
            public IFormFile Photo { get; set; }
            [JsonProperty("userRole")]
            public IList<string> UserRole { get; set; }


    }
    public class User_Profile
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
        [JsonProperty("photo")]
        public string Photo { get; set; }
    }
}
