using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.ResponseModel.Menu;
using Model.ResponseModel.User;
using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utlity;

namespace BroadcastClient.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        private readonly IApiService _apiService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SidebarViewComponent(IApiService apiService,
            IHttpContextAccessor httpContextAccessor)
        {
            _apiService = apiService;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string UserId = "";
            byte[] byteArray;
            var isSessionExist = _httpContextAccessor.HttpContext.Session.TryGetValue(Constant.UserId, out byteArray);
            if (isSessionExist)
                UserId = Encoding.UTF8.GetString(byteArray);

            var result = _apiService.Get<MenuPermissionByUserIdResponseModel>
                (string.Format("api/MenuRole/MenuPermissionByUserRoles?userId={0}&type=2", UserId));

            var menus = new List<MenuPermitList>();
            if (result.success)
                menus = result.response.Data;

            var res = _apiService.Get<MenuResponseModel>("api/Menu/List");
            List<MenuObject> menulist = res.response.Menus;
            var rs = _apiService.Get<UserProfile>(string.Format("User/UserDetails"));
            var data = rs.response;
            return await Task.FromResult((IViewComponentResult)View("Sidebar",data));
            
        }
        
    }
}
