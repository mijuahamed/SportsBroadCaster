using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.ResponseModel
{
    public class RoleDetailsResponseModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("roleName")]
        public string RoleName { get; set; }
    }
}
