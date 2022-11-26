using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.RequestModel;
using Model.ResponseModel;
using Service.API;
using System.Collections.Generic;

namespace BroadcastClient.Controllers.UserRole
{
    public class UserRoleController : Controller
    {
        private readonly IApiService _apiService;

        public UserRoleController(IApiService apiService)
        {
            _apiService = apiService;
        }
        public IActionResult Index()
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
                ResponseModel>("UserRole/CreateRole", model);

            if (!result.success)
            {
                ViewBag.Message = result.error;
                return View();
            }

            return RedirectToAction(controllerName: "UserRole", actionName: "Roles");
        }
        [HttpGet]
        public IActionResult DeleteRole(string roleId)
        {
            var result = _apiService.Get<ResponseModel>(string.Format("UserRole/DeleteRole?roleId={0}", roleId));
            return RedirectToAction(controllerName: "UserRole", actionName: "Roles");
        }

        [HttpGet]
        public IActionResult DetailsRole(string roleId)
        {
            var result = _apiService.Get<RoleDetailsResponseModel>(string.Format("UserRole/Details?roleId={0}", roleId));
            var data = result.response;
            return View(data);
        }
        [HttpGet]
        public IActionResult EditRole(string roleId)
        {
            var result = _apiService.Get<EditRoleResponseModel>(string.Format("UserRole/Details?roleId={0}", roleId));
            var data = result.response;
            return View(data);
        }
        [HttpPost]
        public IActionResult EditRole(EditRoleResponseModel model)
        {
            var result = _apiService.Post<EditRoleResponseModel,
                ResponseModel>("UserRole/EditRole", model);
            if (!result.success)
            {
                ViewBag.Message = result.error;
                return View();
            }

            return RedirectToAction(controllerName: "UserRole", actionName: "Roles");
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
                ResponseModel>(string.Format("UserRole/EditUsersInRole?roleId={0}", roleId), model);
            var list = result.response;
            return RedirectToAction(controllerName: "UserRole", actionName: "Roles");
        }
        [HttpGet]
        public IActionResult EditMenuInRole(string roleId)
        {
            var result = _apiService.Get<List<MenuRoleRseponseModel>>(string.Format("api/MenuRole/MenuAssignedByRoleId?roleId={0}", roleId));
            var list = result.response;
            return View(list);
        }


        [HttpPost]
        public IActionResult EditMenuInRole(List<MenuRoleRseponseModel> model, string roleId)
        {
            var result = _apiService.Post<List<MenuRoleRseponseModel>,
                ResponseModel>(string.Format("api/MenuRole/AddMenuPermission?roleId={0}",roleId), model);
            var list = result.response;
            return RedirectToAction(controllerName: "UserRole", actionName: "Roles");
        }


    }
}
