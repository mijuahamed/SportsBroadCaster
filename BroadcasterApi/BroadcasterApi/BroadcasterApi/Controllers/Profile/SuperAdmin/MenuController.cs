using BroadcasterApi.Controllers.Generic;
using BroadcasterApi.CustomFiltering;
using BroadcasterApi.Factory;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel;

namespace BroadcasterApi.Controllers.Profile.SuperAdmin
{
    //[AuthorizationFilter("SuperAdmin,Person")]
    [Route("api/Menu/[action]")]
    [ApiController]
    public class MenuController : GenericController<Menu, MenuViewModel>
    {
        public MenuController(IGenericFactory<Menu> genericFactory) : base(genericFactory)
        {

        }
    }
}
