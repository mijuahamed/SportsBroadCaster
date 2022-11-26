using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Model.ResponseModel
{
    public class EditRoleResponseModel
    {

        [JsonProperty("id")]

        public string Id { get; set; }

        [JsonProperty("roleName")]
        public string RoleName { get; set; }
    }
}
