using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.RequestModel
{
    public class CreateRoleRequestModel
    {
        [JsonProperty("roleName")]
        public string RoleName { get; set; }
    }
}
