using System;
using System.Collections.Generic;
using System.Text;

namespace Utlity
{
    public static class Constant
    {
        public static readonly string BaseUrl = "https://localhost:44377/{0}";
        #region UserInfo
        public static readonly string SessionTokenKey = "_Token";
        public static readonly string UserId = "_UserId";
        #endregion
        #region HttpErrors
        public static readonly string UnAuthorized = "UnAuthorized Action";
        #endregion

    }
}
