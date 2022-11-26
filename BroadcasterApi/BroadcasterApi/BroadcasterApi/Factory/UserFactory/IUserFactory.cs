using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BroadcasterApi.Factory.UserFactory
{
    public interface IUserFactory
    {
        string GetUserId();
        string GetUserName();
        List<string> GetUserRole();
    }
}
