using Microsoft.AspNetCore.Mvc;
using Model.ResponseModel.User;
using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BroadcastClient.ViewComponents
{
    public class TableViewComponent : ViewComponent
    {
        private readonly IApiService _apiService;
        public TableViewComponent(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = _apiService.Get<List_of_User_ResponseModel>("User/ListUsers");
            List<UserObject> UserList = result.response.Users;
            return await Task.FromResult((IViewComponentResult)View("Table", UserList));
        }
    }
}
