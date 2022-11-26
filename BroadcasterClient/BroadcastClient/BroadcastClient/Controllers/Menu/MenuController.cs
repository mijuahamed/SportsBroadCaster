using Microsoft.AspNetCore.Mvc;
using Model.RequestModel.Menu;
using Model.ResponseModel;
using Model.ResponseModel.Menu;
using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BroadcastClient.Controllers.Menu
{
    public class MenuController : Controller
    {
        private readonly IApiService _apiService;

        public MenuController(IApiService apiService)
        {
            _apiService = apiService;
        }
        public IActionResult Index()
        {
            var result = _apiService.Get<MenuResponseModel>("api/Menu/List");
            List<MenuObject> menulist = result.response.Menus;
            return View(menulist);
        }
       
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateMenuRequestModel model)
        {
            var result = _apiService.Post<CreateMenuRequestModel,
                ResponseModel>("api/Menu/Insert", model);

            if (!result.success)
            {
                ViewBag.Message = result.error;
                return View();
            }

            return RedirectToAction(controllerName: "Menu", actionName: "Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var result = _apiService.Get<ResponseModel>(string.Format("api/Menu/Delete?id={0}", id));
            return RedirectToAction(controllerName: "Menu", actionName: "Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var result = _apiService.Get<MenuObject>(string.Format("api/Menu/Details?id={0}", id));
            var data = result.response;
            return View(data);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = _apiService.Get<MenuObject>(string.Format("api/Menu/Details?id={0}", id));
            var data = result.response;
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(MenuObject model)
        {
            var result = _apiService.Post<MenuObject,
                ResponseModel>("api/Menu/Update", model);
            if (!result.success)
            {
                ViewBag.Message = result.error;
                return View();
            }
            return RedirectToAction(controllerName: "Menu", actionName: "Index");
        }
        
    }
}
