using AccessManagerApp.DTOs;
using AccessManagerApp.Models;
using AutoMapper;
using System;
using System.Text.Json;

namespace AccessManagerApp.Helpers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AccountType, AccountTypeDTO>().ReverseMap();     
         
            CreateMap<AccountDTO, Account>()
                .Include<AccountNormalDTO, AccNormal>()
                .Include<AccountEmailDTO, AccEmailAssociated>()
                .Include<AccountCardDTO, AccCard>()
                .Include<AccountWebAssociatedDTO, AccWebSite>().ReverseMap();

            CreateMap<AccountNormalDTO, AccNormal>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => Encrypter.EncryptPlainText(src.Password)));
            CreateMap<AccountEmailDTO, AccEmailAssociated>().ReverseMap();
            CreateMap<AccountCardDTO, AccCard>().ReverseMap();
            CreateMap<AccountWebAssociatedDTO, AccWebSite>().ReverseMap();

            CreateMap<AccNormal, AccountNormalDTO>()
              .ForMember(dest => dest.Password, opt => opt.MapFrom(src => Encrypter.DecryptString(src.Password)));

            CreateMap<AccountDetailDTO, AccountDetails>()
                .ForMember(dest => dest.ValueTag, opt => opt.MapFrom(src => src.IsSensitive ? 
                    Encrypter.EncryptPlainText(src.ValueTag) 
                    : src.ValueTag));

            CreateMap<AccountDetails, AccountDetailDTO>()
                .ForMember(dest => dest.ValueTag, opt => opt.MapFrom(src => src.IsSensitive ? 
                    Encrypter.DecryptString(src.ValueTag)
                    :src.ValueTag));
           


        }
    }
}
