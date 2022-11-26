using AutoMapper;
using BLL;
using BroadcasterApi.Factory.MenuRoleFactory;
using BroadcasterApi.ViewModel.File;
using Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BroadcasterApi.Factory.FileFactory
{
    public class FileFactory : GenericFactory<File>,IFileFactory
    {
        private readonly IGenericService<File> _fileService;
        
        public FileFactory(IGenericService<File> fileService,
            IMapper mapper
            ) : base(fileService, mapper)
        {
            _fileService = fileService;
            
        }

        public async Task<(bool result, string message, string error, File data)> Insert(FileViewModel model)
        {
            var m = new File()
            {
                Name = model.Name,
                Path = model.Path,
                Type = model.Type,
                Source = model.Source
            };
            var response = await _fileService.Insert(m);

            return (true, "Data Insersted Successfully", null, response.data);
        }
    }
}
