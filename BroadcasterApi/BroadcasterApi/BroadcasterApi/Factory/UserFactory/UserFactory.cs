using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BroadcasterApi.Factory.UserFactory
{
    public class UserFactory : IUserFactory
    {
        private readonly IUserService _userService;
        public UserFactory(IUserService userService)
        {
            _userService = userService;
        }
        public string GetUserId()
        {
            var userClaims = _userService.GetUserClaims();
            var userId = userClaims.Where(x => x.Type == "UserId").Select(x=> x.Value).FirstOrDefault();
            return userId;
        }
        public string GetUserName()
        {
            var userClaims = _userService.GetUserClaims();
            var userName = userClaims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value).FirstOrDefault();
            return userName;
        }

        public List<string> GetUserRole()
        {
            var userClaims = _userService.GetUserClaims();
            var userRoles = userClaims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value).ToList();
            return userRoles;
        }
    }
}
