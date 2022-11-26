using BroadcasterApi.Controllers.Generic;
using BroadcasterApi.CustomFiltering;
using BroadcasterApi.Extension;
using BroadcasterApi.Factory;
using BroadcasterApi.Factory.FileFactory;
using BroadcasterApi.Factory.RestFactory;
using BroadcasterApi.Factory.UserFactory;
using BroadcasterApi.Factory.UserFileFactory;
using BroadcasterApi.ViewModel.EditUser;
using BroadcasterApi.ViewModel.File;
using BroadcasterApi.ViewModel.Football;
using BroadcasterApi.ViewModel.UserProfile;
using Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Utility;
using ViewModel;
using File = Entity.File;

namespace BroadcasterApi.Controllers.Profile.SuperAdmin
{
    //[AuthorizationFilter("SuperAdmin")]
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : GenericController<File, FileViewModel>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserFactory _userFactory;
        private readonly IHostingEnvironment _env;
        private readonly IFileFactory _fileFactory;
        private readonly IUserFileFactory _userFileFactory;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager,
            IUserFactory userFactory, IHostingEnvironment env, IGenericFactory<File> genericFactory,
            IFileFactory fileFactory, IUserFileFactory userFileFactory) : base(genericFactory)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _userFactory = userFactory;
            _env = env;
            _fileFactory = fileFactory;
            _userFileFactory = userFileFactory;
        }
        public IActionResult Index()
        {
            return Ok();
        }

        [AuthorizationFilter("SuperAdmin")]
        [HttpGet]
        public IActionResult ListUsers()
        {
            var users = _userManager.Users.Select(x => new { x.UserName, x.Address, x.Age, x.Email, x.PhoneNumber, x.Id, x.IsActive });
            return Ok(new { success = true, message = users.Any() ? "Data Fetch Successfully" : "Empty List", error = "", data = users });
        }
        
        [AuthorizationFilter("SuperAdmin")]
        [HttpGet]

        public async Task<IActionResult> DetailsByUserId(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var model = new EditUserViewModel
            {
                UserName = user.UserName,
                Age = user.Age,
                Address = user.Address,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };

            return Ok(model);
        }
        [AuthorizationFilter("Person")]
        [HttpGet]
        public async Task<IActionResult> Football(string id)
        {

            if (string.IsNullOrEmpty(id))
                id = "";

            RestApi restApi = new RestApi();
            var body = await restApi.ApiGet(Constant.FootballApi);

            var list = JsonConvert.DeserializeObject<List<Football>>(body);
            var competitionName = list.Select(x => x.Competition.Name).Distinct().ToList();

            var result = list.Where(x => x.Competition.Name.ToLower().Contains(id.ToLower())).ToList();
            result = result.OrderByDescending(x => x.date).ToList();
            return Ok(new { success = true, message = result.Any() ? "Data Fetch Successfully" : "Empty List", error = "", data = result });
        }

        [AuthorizationFilter("Person,SuperAdmin,Admin")]
        [HttpGet]
        public async Task<IActionResult> UserDetails()
        {

            var Id = _userFactory.GetUserId();
            var user = await _userManager.FindByIdAsync(Id);
            var roles = await _userManager.GetRolesAsync(user);

            if (user == null)
            {
                return NotFound();
            }

            var model = new
            {
                Id = Id,
                UserName = user.UserName,
                Age = user.Age,
                Address = user.Address,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                UserRole = roles

            };

            return Ok(model);
        }

        [AuthorizationFilter("Person,SuperAdmin,Admin")]
        [HttpPost]
        public async Task<IActionResult> UserProfile(UserProfileViewModel model)
        {

            var user = await _userManager.FindByIdAsync(model.Id);

            if (user == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(model.Photo))
            {

                string fileName = Guid.NewGuid().ToString();
                var filetype = model.Photo.GetFileExtensionMethod();
                string outputImgFilename = (fileName + "." + filetype);
                var folderPath = System.IO.Path.Combine(_env.ContentRootPath, "wwwroot/Images");
                if (!System.IO.Directory.Exists(folderPath))
                {
                    System.IO.Directory.CreateDirectory(folderPath);
                }
                System.IO.File.WriteAllBytes(Path.Combine(folderPath, outputImgFilename), Convert.FromBase64String(model.Photo));


                var filedata = new FileViewModel
                {
                    Name = fileName,
                    Path = folderPath,
                    Type = filetype
                };
                var file_result = await _fileFactory.Insert(filedata);

                // return Ok(new { success = true, message = "Created Successfully", error = "", data = results });
                var userfiledata = new UserFileViewModel
                {
                    UserId = user.Id,
                    FileId = file_result.data.Id

                };
                var user_file_results = await _userFileFactory.Insert(userfiledata);
            }

            user.UserName = model.UserName;
            user.Email = model.Email;
            user.Address = model.Address;
            user.PhoneNumber = model.PhoneNumber;
            user.Age = model.Age;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return Ok(new { success = true, message = "User Updated Successfully", error = "", data = result });
            }

            return StatusCode(500);
        }


        [AuthorizationFilter("SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);

            if (user == null)
            {
                return NotFound();
            }

            user.UserName = model.UserName;
            user.Email = model.Email;
            user.Address = model.Address;
            user.PhoneNumber = model.PhoneNumber;
            user.Age = model.Age;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return Ok(new { success = true, message = "User Updated Successfully", error = "", data = result });
            }

            return StatusCode(500);
        }

        [AuthorizationFilter("SuperAdmin")]
        [HttpGet]
        public async Task<IActionResult> ChangeActiveStatus(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            user.IsActive = !user.IsActive;
            await _userManager.UpdateAsync(user);
            return Ok(new { message = "User Status Changed Succssfully", data = user });
        }
    }
}
