using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BroadcasterApi.ViewModel.LoginRegistration
{
    public class ResponseLoginViewModel
    {
        public bool Success { set; get; }
        public string Message { set; get; }
        public string UserId { set; get; }
        public string Token { set; get; }
        public IList<string> UserRole { get; set; }
    }
}
