using BroadcasterApi.Controllers.Generic;
using BroadcasterApi.CustomFiltering;
using BroadcasterApi.Factory;
using BroadcasterApi.Factory.MenuRoleFactory;
using BroadcasterApi.ViewModel.MenuRole;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel.MenuPermission;

namespace BroadcasterApi.Controllers.Profile.SuperAdmin
{
    //[AuthorizationFilter("SuperAdmin")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MenuRoleController : GenericController<MenuRole, MenuRoleViewModel>
    {
        private readonly IMenuRoleFactory _menuRoleFactory;
        public MenuRoleController(IGenericFactory<MenuRole> genericFactory,
            IMenuRoleFactory menuRoleFactory) : base(genericFactory)
        {
            _menuRoleFactory = menuRoleFactory;
        }
        [AuthorizationFilter("SuperAdmin")]
        // [AuthorizationFilter("Person")]
        [HttpGet]
        public async Task<IActionResult> MenuAssignedByRoleId(string roleId)
        {
            var response = await _menuRoleFactory.GetAssignedMenuByRoleId(roleId);
            if (!response.success)
                return StatusCode(500);
            var list = response.data;

            return Ok(list);
        }
        [AuthorizationFilter("SuperAdmin")]
        // [AuthorizationFilter("Person")]
        [HttpPost]
        public override async Task<IActionResult> Insert(MenuRoleViewModel model)
        {
            var result = await _menuRoleFactory.Insert(model);
            return Ok(new { success = true, message = "Created Successfully", error = "", data = result });
        }
        [AuthorizationFilter("SuperAdmin")]
        // [AuthorizationFilter("Person")]
        [HttpPost]
        public async Task<IActionResult> AddMenuPermission(List<MenuPermission> model , string roleId)
        {
            var response = await _menuRoleFactory.SaveMenuPermission(model, roleId);
            if (!response.success)
                return StatusCode(500,response.message);

            return Ok(new { success = true, message = response.message , error = response.error});
        }
        //[AuthorizationFilter("SuperAdmin")]
         [AuthorizationFilter("Person,SuperAdmin")]
        [HttpGet]
        public async Task<IActionResult> MenuPermissionByUserRoles(string userId, int type)
        {
            var response = await _menuRoleFactory.MenuPermissionByUserId(userId,type);
            return Ok(new { success = response.success, message = response.message, error = response.error, data = response.data });
        }
    }

}
