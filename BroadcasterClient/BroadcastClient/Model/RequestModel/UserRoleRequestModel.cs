using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.RequestModel
{
    public class UserRoleRequestModel
    {
        [JsonProperty("roleId")]
        public string RoleId { get; set; }
    }
}
