using BroadcastClient.Extension;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Model.RequestModel;
using Model.ResponseModel;
using Model.ResponseModel.Football;
using Model.ResponseModel.User;
using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BroadcastClient.Controllers.User
{
    public class UserController : Controller
    {
        private readonly IApiService _apiService;
        public UserController(IApiService apiService)
        {
            _apiService = apiService;
        }
        public IActionResult Index()
        {
            var result = _apiService.Get<List_of_User_ResponseModel>("User/ListUsers");
            List<UserObject> UserList = result.response.Users;
            return View(UserList);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(RegistrationRequestModel model)
        {
            var result = _apiService.Post<RegistrationRequestModel,
                ResponseModel>("Account/Registration", model);

            if (!result.success)
            {
                ViewBag.Message = result.error;
                return View();
            }

            return RedirectToAction(controllerName: "Report", actionName: "Index");
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            var result = _apiService.Get<UserObject>(string.Format("User/DetailsByUserId?id={0}", id));
            var data = result.response;
            return View(data);
        }
        [HttpGet]
        public IActionResult Football(string id)
        {
            var result = _apiService.Get<List_of_Football_ResponseModel>(string.Format("User/Football?id={0}",id));
            List<FootballObject>  MatchList = result.response.data;
            return View(MatchList);

        }
        [HttpGet]
        public IActionResult FootballMatchWatch(string embed)
        {
            FootballResponseModel data = new FootballResponseModel();
            data.embed= embed;
            return View(data);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var result = _apiService.Get<UserObject>(string.Format("User/DetailsByUserId?id={0}", id));
            var data = result.response;
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(UserObject model)
        {
            var result = _apiService.Post<UserObject,
                ResponseModel>("User/EditUser", model);
            if (!result.success)
            {
                ViewBag.Message = result.error;
                return View();
            }
            //return RedirectToAction(controllerName: "User", actionName: "Index");
            return RedirectToAction(controllerName: "Report", actionName: "Index");

        }
        [HttpGet]
        public IActionResult Profile()
        {
            var result = _apiService.Get<UserProfile>(string.Format("User/UserDetails"));
            var data = result.response;
            return View(data);
        }
        [HttpPost]
        public IActionResult Profile(UserProfile model)
        {
            var base64 = model.Photo.FormFileToBase64();

            var usermodel = new User_Profile
            {
                Address=model.Address,
                Age=model.Age,
                Email=model.Email,
                Id=model.Id,
                PhoneNumber=model.PhoneNumber,
                UserName=model.UserName,
                Photo=base64
            };


            var result = _apiService.Post<User_Profile,
                ResponseModel>("User/UserProfile", usermodel);
            if (!result.success)
            {
                ViewBag.Message = result.error;
                return View();
            }
            var res = _apiService.Get<UserProfile>(string.Format("User/UserDetails"));
            var data = res.response;

            var role =res.response.UserRole;
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

        [HttpGet]
        public IActionResult ActiveStatus(string id)
        {
            var result = _apiService.Get<UserObject>(string.Format("User/ChangeActiveStatus?id={0}", id));
            var data = result.response;
            return RedirectToAction(controllerName: "User", actionName: "Index");
        }

    }
}
