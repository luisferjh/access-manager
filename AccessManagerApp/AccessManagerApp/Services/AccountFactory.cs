using AccessManagerApp.DTOs;
using AccessManagerApp.Helpers;
using AccessManagerApp.Models;
using AutoMapper;
using System;
using System.Text.Json;

namespace AccessManagerApp.Services
{
    public abstract class CreateAccountFactory
    {
        protected abstract AccountDTO MakeAccount();
        public AccountDTO CreateAccount() 
        {
            return MakeAccount();
        }
    }

    public class AccountNormalFactory: CreateAccountFactory
    {     
        public AccountPOSTDTO _modelDto { get; set; }
        public AccountNormalFactory(AccountPOSTDTO model)
        {
            _modelDto = model;
            _modelDto.AccountTypeObj = JsonSerializer.Deserialize<AccountNormalDTO>(_modelDto.AccountTypeObj.ToString());                       
        }

        protected override AccountDTO MakeAccount()
        {
            IMapper _mapper = StaticServiceProvider.GetService<IMapper>();
            AccountDTO accDto = _modelDto.MappingAccount<AccountNormalDTO>();                       
            return accDto;
        }
    }

    public class AccountEmailFactory : CreateAccountFactory
    {
        public AccountPOSTDTO _modelDto { get; set; }
        public AccountEmailFactory(AccountPOSTDTO model)
        {
            _modelDto = model;
            _modelDto.AccountTypeObj = JsonSerializer.Deserialize<AccountEmailDTO>(_modelDto.AccountTypeObj.ToString());            
        }
        protected override AccountDTO MakeAccount()
        {
            IMapper _mapper = StaticServiceProvider.GetService<IMapper>();
            AccountDTO accDto = _modelDto.MappingAccount<AccountEmailDTO>();           
            return accDto;
        }
    }

    public class AccountWebSiteFactory : CreateAccountFactory
    {
        public AccountPOSTDTO _modelDto { get; set; }
        public AccountWebSiteFactory(AccountPOSTDTO model)
        {
            _modelDto = model;
            _modelDto.AccountTypeObj = JsonSerializer.Deserialize<AccountWebAssociatedDTO>(_modelDto.AccountTypeObj.ToString());           
        }
        protected override AccountDTO MakeAccount()
        {
            IMapper _mapper = StaticServiceProvider.GetService<IMapper>();
            AccountDTO accDto = _modelDto.MappingAccount<AccountWebAssociatedDTO>();            
            return accDto;
        }
    }

    public class AccountCardFactory : CreateAccountFactory
    {
        public AccountPOSTDTO _modelDto { get; set; }
        public AccountCardFactory(AccountPOSTDTO model)
        {
            _modelDto = model;
            _modelDto.AccountTypeObj = JsonSerializer.Deserialize<AccountCardDTO>(_modelDto.AccountTypeObj.ToString());            
        }
        protected override AccountDTO MakeAccount()
        {
            IMapper _mapper = StaticServiceProvider.GetService<IMapper>();
            AccountDTO accDto = _modelDto.MappingAccount<AccountCardDTO>();           
            return accDto;
        }
    }

    public static class AccountFactory
    {
        public static AccountDTO CreateAccountObject(AccountPOSTDTO accountModelDTO)
        {
            AccountDTO _account = accountModelDTO.CodeAccountType switch
            {
                "001" => new AccountNormalFactory(accountModelDTO).CreateAccount(),
                "002" => new AccountEmailFactory(accountModelDTO).CreateAccount(),
                "003" => new AccountWebSiteFactory(accountModelDTO).CreateAccount(),
                "004" => new AccountCardFactory(accountModelDTO).CreateAccount(),
                _ => null
            };

            return _account;
        }

    }
   
}
