using System;
using AccountingApp.Models;
using AccountingApp.Models.ViewModels;
using AutoMapper;

namespace AccountingApp.App_Code
{
    public class AutoMapperClass : Profile
    {
        /// <summary>
        /// Mapper class
        /// </summary>
        public AutoMapperClass()
        {
            // map for AdminUserEdit <-> AppUser 
            CreateMap<AdminUserEdit, AppUser>().ReverseMap();

            // map for UserEdit <-> AppUser 
            CreateMap<UserEdit, AppUser>().ReverseMap();
        }
    }
}
