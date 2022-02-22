using AccessManagerApp.DTOs;
using AccessManagerApp.Models;
using AutoMapper;

namespace AccessManagerApp.Helpers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AccountType, AccountTypeDTO>();
        }
    }
}
