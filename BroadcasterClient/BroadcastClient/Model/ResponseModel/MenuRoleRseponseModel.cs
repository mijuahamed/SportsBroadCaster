using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ResponseModel
{
    public class MenuRoleRseponseModel
    {
        [JsonProperty("menuId")]
        public int MenuId { get; set; }
        [JsonProperty("menuName")]
        public string MenuName { get; set; }
        [JsonProperty("isSelected")]
        public bool IsSelected { get; set; }
    }
}
