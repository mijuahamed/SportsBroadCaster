using System.Collections.Generic;
using System.Security.Claims;

namespace BLL
{
    public interface IUserService
    {
        List<Claim> GetUserClaims();
    }
}
