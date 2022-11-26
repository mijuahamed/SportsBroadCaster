using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.RequestModel
{
    public class DeleteRoleRequestModel
    {
        [JsonProperty("roleId")]
        public string RoleId { get; set; }
    }
}
