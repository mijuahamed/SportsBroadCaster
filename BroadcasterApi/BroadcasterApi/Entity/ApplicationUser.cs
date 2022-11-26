using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(250)]
        public string Address { set; get; }
        [MaxLength(10)]
        public string Gender { set; get; }
        public int Age { set; get; }
        public bool IsActive { set; get; }
    }
}
