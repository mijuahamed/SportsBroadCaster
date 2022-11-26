using AutoMapper;
using BroadcasterApi.ViewModel.File;
using Entity;
using ViewModel;

namespace BroadcasterApi.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //CreateMap<DBTbl_Student, StudentViewModel>().ReverseMap();


            CreateMap<Menu, MenuViewModel>().ReverseMap();
            CreateMap<MenuRole, MenuRoleViewModel>().ReverseMap();
            CreateMap<File, FileViewModel>().ReverseMap();
            CreateMap<UserFile, UserFileViewModel>().ReverseMap();

        }
    }
}
