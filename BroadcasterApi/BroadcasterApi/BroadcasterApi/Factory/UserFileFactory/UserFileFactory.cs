using AutoMapper;
using BLL;
using BroadcasterApi.Factory.MenuRoleFactory;
using Entity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using ViewModel;
using ViewModel.MenuPermission;

namespace BroadcasterApi.Factory.UserFileFactory
{
    public class UserFileFactory : GenericFactory<UserFile> , IUserFileFactory
    {
        private readonly IGenericService<UserFile> _userFileService;
        private readonly IGenericService<File> _fileService;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserFileFactory(IGenericService<UserFile> userFileService,
            IMapper mapper,
            IGenericService<File> fileService,
            UserManager<ApplicationUser> userManager) : base(userFileService, mapper)
        {
            _userFileService = userFileService;
            _fileService = fileService;
            _userManager = userManager;
        }

        public async Task<(bool result, string mesage, string error)> Insert(UserFileViewModel model)
        {
            var m = new UserFile()
            {
                FileId = model.FileId,
                UserId = model.UserId
            };
            var response = await _userFileService.Insert(m);
            return (true, "Data Insersted Successfully", null); ;
        }


    }
}
