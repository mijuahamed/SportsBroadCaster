using BroadcastClient.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.RequestModel;
using Model.ResponseModel;
using Service;
using Service.API;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Utlity;

namespace BroadcastClient.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApiService _apiService;

               public HomeController(ILogger<HomeController> logger,
            IApiService apiService)
        {
            _logger = logger;
            _apiService = apiService;
        }
        public IActionResult Index()
        {
            var result = _apiService.Get<List<WeatherForecastResponseModel>>("weatherforecast");
            return View(result.response);
        }

        public IActionResult Registration()
        {
            return View();
        }
        public IActionResult Roles()
        {
            var result = _apiService.Get<List_of_Role_ResponseModel>("UserRole/ListRoles");
            List<RoleObject> Rols = result.response.Roles;
            return View(Rols);
        }
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateRole(CreateRoleRequestModel model)
        {
            var result = _apiService.Post<CreateRoleRequestModel,
                ResponseModel>("UserRole/CreateRole" , model);

            if (!result.success)
            {
                ViewBag.Message = result.error;
                return View();
            }

            return RedirectToAction(controllerName:"Home" , actionName:"Roles");
        }
        [HttpGet]
        public IActionResult DeleteRole(string roleId)
        {
            var result=_apiService.Get<ResponseModel>(string.Format("UserRole/DeleteRole?roleId={0}",roleId));
            return RedirectToAction(controllerName: "Home", actionName: "Roles");
        }
        [HttpGet]
        public IActionResult EditUsersInRole(string roleId)
        {
            var result = _apiService.Get<List<UserRoleRseponseModel>>(string.Format("UserRole/EditUsersInRole?roleId={0}", roleId));
            var list = result.response;
            return View(list);
        }
        [HttpPost]
        public IActionResult EditUsersInRole(List<UserRoleRseponseModel> model, string roleId)
        {
            var result = _apiService.Post<List<UserRoleRseponseModel>,
                ResponseModel>(string.Format("UserRole/EditUsersInRole?roleId={0}", roleId),model);
            var list = result.response;
            return RedirectToAction(controllerName: "Home", actionName: "Roles");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.SetString(Constant.SessionTokenKey, "");
            return RedirectToAction(controllerName: "Account", actionName: "Login");
        }

        public IActionResult GetToken()
        {
            var token = HttpContext.Session.GetString(Constant.SessionTokenKey);
            return Ok(new { token = token});
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var pathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            Exception exception = pathFeature?.Error;
            if (exception.Message.Equals(Constant.UnAuthorized))
            {
                return RedirectToAction(controllerName: "Account", actionName: "Login");
            }
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
      
    }
}
