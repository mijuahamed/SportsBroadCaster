using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class MenuRole:BaseEntity
    {
        [ForeignKey("Menu")]
        public int MenuId { set; get; }
        public Menu Menu { set; get; }
       // [ForeignKey("IdentityRole")]
        public string RoleId { set; get; }
       // public IdentityRole IdentityRole { set; get; }

    }
}
