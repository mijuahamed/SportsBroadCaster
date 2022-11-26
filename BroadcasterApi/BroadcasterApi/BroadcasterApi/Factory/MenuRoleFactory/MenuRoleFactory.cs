using AutoMapper;
using BLL;
using BroadcasterApi.ViewModel.MenuRole;
using Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel.MenuPermission;

namespace BroadcasterApi.Factory.MenuRoleFactory
{
    public class MenuRoleFactory : GenericFactory<MenuRole>, IMenuRoleFactory
    {
        private readonly IGenericService<MenuRole> _menuRoleService;
        private readonly IGenericService<Menu> _menuService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public MenuRoleFactory(IGenericService<MenuRole> menuRoleService,
            IMapper mapper,
            IGenericService<Menu> menuService,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager) : base(menuRoleService, mapper)
        {
            _menuRoleService = menuRoleService;
            _menuService = menuService;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<(bool result, string mesage, string error)> Insert(MenuRoleViewModel model)
        {
            var m = new MenuRole()
            {
                MenuId = model.MenuId,
                RoleId = model.RoleId
            };
            var response = await _menuRoleService.Insert(m);
            return (true, "Data Insersted Successfully", null); ;
        }

        public async Task<(bool success, string message, string error, List<MenuRoleAssignViewModel> data)>
            GetAssignedMenuByRoleId(string roleId)
        {
            try
            {
                var query = (from a in _menuService.Get()
                             select new MenuRoleAssignViewModel()
                             {
                                 MenuId = a.Id,
                                 MenuName = a.Name,
                                 IsSelected = (from b in _menuRoleService.Get()
                                               where b.RoleId == roleId && b.MenuId == a.Id
                                               select b.RoleId)
                                              .Any()
                             });

                var data = await query.ToListAsync();

                return (true, "Data Fecth Successfully", null, data);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, ex.ToString(), null);
            }
        }

        public async Task<(bool success, string message, string error)> SaveMenuPermission(List<MenuPermission> model, string roleId)
        {
            try
            {
                foreach (var x in model)
                {
                    var menuRole = new MenuRole()
                    {
                        MenuId = x.MenuId,
                        RoleId = roleId
                    };

                    if (x.IsSelected)
                    {
                        var isExist = _menuRoleService.Get(y => y.MenuId == x.MenuId && y.RoleId == roleId).Any();
                        if (!isExist)
                        {
                            await _menuRoleService.Insert(menuRole);
                        }
                    }
                    else
                    {
                        var entity = await _menuRoleService.GetEntity(y => y.MenuId == x.MenuId && y.RoleId == roleId);

                        if (entity != null)
                        {
                            await _menuRoleService.Delete(entity);
                        }
                    }
                }
                return (true, "Permission Saved Successfully", null);
            }
            catch(Exception ex)
            {
                return (false, ex.Message, ex.ToString());
            }
        }

        public async Task<(bool success, string message, string error, List<MenuPermissionWithUser> data)> MenuPermissionByUserId(string UserId, int type)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(UserId);
                var userRole = await _userManager.GetRolesAsync(user);
                var roles = _roleManager.Roles.Where(x => userRole.Contains(x.Name)).Select(x=> x.Id).ToList();

                var menuRoleList = await _menuRoleService.GetListAsync(x => roles.Contains(x.RoleId));

                var data =  (from a in menuRoleList
                            select new MenuPermissionWithUser
                            {
                                Name = (from b in _menuService.Get(x => x.Id == a.MenuId)
                                        where b.Type == type
                                        select b.Name).FirstOrDefault(),

                                Id = (from b in _menuService.Get(x => x.Id == a.MenuId)
                                      where b.Type == type
                                      select b.Id).FirstOrDefault(),

                                ParentId = (from b in _menuService.Get(x => x.Id == a.MenuId)
                                            where b.Type == type
                                            select b.RootId).FirstOrDefault(),

                            }).Distinct().ToList(); 

                return (true, "data fatched successfully", null, data);
            }
            catch(Exception ex)
            {
                return (false, ex.Message, ex.ToString(), null);
            }
        }

    }
}
