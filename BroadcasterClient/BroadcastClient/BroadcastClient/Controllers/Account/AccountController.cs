using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Model.RequestModel;
using Model.ResponseModel;
using Service.API;
using System.Reflection;
using System.Threading.Tasks;
using Utlity;

namespace BroadcastClient.Controllers.Account
{
    public class AccountController : Controller
    {
        private readonly IApiService _apiService;
        public AccountController(IApiService apiService)
        {
            _apiService = apiService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(RegistrationRequestModel model)
        {
            var result = _apiService.Post<RegistrationRequestModel,
                ResponseModel>("Account/Registration", model);

            if (!result.success)
            {
                ViewBag.Message = result.error;
                return View();
            }

            return RedirectToAction(controllerName: "Account", actionName: "Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginRequestModel model)
        {
            var result = _apiService.Post<LoginRequestModel,
                LoginResponseModel>("Account/Login", model);

            if (!result.response.Success)
            {
                ModelState.AddModelError(string.Empty , result.response.Message);
                return View();
            }

            HttpContext.Session.SetString(Constant.SessionTokenKey, result.response.Token);
            HttpContext.Session.SetString(Constant.UserId, result.response.UserId);
            var role= result.response.UserRole;
            string joined = string.Join(",", role);
            if (joined == "Person")
            {
                return RedirectToAction(controllerName: "User", actionName: "Football");
            }
            else if (joined == "SuperAdmin")
            {
                return RedirectToAction(controllerName: "Report", actionName: "Index");
            }
            else 
            {
                return RedirectToAction(controllerName: "Admin", actionName: "Index");
            }
        }
        [HttpPost]
        public IActionResult LogOff(LoginRequestModel model)
        {
            var result = _apiService.Post<LoginRequestModel,
                LoginResponseModel>("Account/Logout", model);
            return RedirectToAction(controllerName: "Account", actionName: "Login");
        }

    }
}
