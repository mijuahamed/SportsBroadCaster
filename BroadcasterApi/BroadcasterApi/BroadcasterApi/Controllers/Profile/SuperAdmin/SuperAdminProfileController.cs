using BroadcasterApi.CustomFiltering;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BroadcasterApi.Controllers.Profile.SuperAdmin
{
    [AuthorizationFilter("SuperAdmin")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SuperAdminProfileController : ControllerBase
    {
    }
}
