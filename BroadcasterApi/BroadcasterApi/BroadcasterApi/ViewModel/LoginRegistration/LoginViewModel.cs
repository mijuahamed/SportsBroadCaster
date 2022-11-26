using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BroadcasterApi.ViewModel.LoginRegistration
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { set; get; }
        [Required]
        public string Password { set; get; }
    }
}
