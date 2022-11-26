using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.RequestModel
{
    public class LoginRequestModel
    {
        [JsonProperty("userName")]
        [Required]
        public string UserName { set; get; }
        [JsonProperty("password")]
        [Required]
        public string Password { set; get; }
    }
}
