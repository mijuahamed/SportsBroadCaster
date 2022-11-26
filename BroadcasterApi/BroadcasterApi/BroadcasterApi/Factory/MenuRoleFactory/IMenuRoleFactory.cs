using BroadcasterApi.ViewModel.MenuRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel.MenuPermission;

namespace BroadcasterApi.Factory.MenuRoleFactory
{
    public interface IMenuRoleFactory
    {
        Task<(bool success, string message, string error, List<MenuRoleAssignViewModel> data)> GetAssignedMenuByRoleId(string roleId);
        Task<(bool result, string mesage, string error)> Insert(MenuRoleViewModel model);
        Task<(bool success, string message, string error)> SaveMenuPermission(List<MenuPermission> model, string roleId);
        Task<(bool success, string message, string error, List<MenuPermissionWithUser> data)> MenuPermissionByUserId(string UserId,int type);
    }
}
