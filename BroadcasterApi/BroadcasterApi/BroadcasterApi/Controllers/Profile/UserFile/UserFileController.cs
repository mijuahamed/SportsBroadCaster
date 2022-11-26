using BroadcasterApi.Controllers.Generic;
using BroadcasterApi.CustomFiltering;
using BroadcasterApi.Factory.MenuRoleFactory;
using BroadcasterApi.Factory;
using Entity;
using Microsoft.AspNetCore.Mvc;
using BroadcasterApi.ViewModel.File;
using BroadcasterApi.Factory.FileFactory;
using System.Threading.Tasks;

namespace BroadcasterApi.Controllers.Profile.UserFile
{
    [AuthorizationFilter("SuperAdmin")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserFileController : GenericController<File, FileViewModel>
    {
        private readonly IFileFactory _fileFactory;
        public UserFileController(IGenericFactory<File> genericFactory,
            IFileFactory fileFactory) : base(genericFactory)
        {
            _fileFactory = fileFactory;
        }

        [HttpPost]
        public override async Task<IActionResult> Insert(FileViewModel model)
        {
            var result = await _fileFactory.Insert(model);
            return Ok(new { success = true, message = "Created Successfully", error = "", data = result });
        }



    }
}
