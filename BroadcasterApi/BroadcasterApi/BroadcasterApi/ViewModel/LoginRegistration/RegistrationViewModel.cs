using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BroadcasterApi.ViewModel.LoginRegistration
{
    public class RegistrationViewModel
    {
        [Required]
        [MaxLength(50)]
        [MinLength(5)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(5)]
        public string Email { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(7)]
        public string Address { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [MaxLength(17)]
        [MinLength(5)]
        public string PhoneNumber { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(8)]
        public string Password { set; get; }
        
       // public bool IsActive { set; get; }
    }
}
