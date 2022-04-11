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
        protected abstract Account MakeAccount();
        public Account CreateAccount() 
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
            _modelDto.GuidAccount = Guid.NewGuid();              
        }

        protected override Account MakeAccount()
        {
            IMapper _mapper = StaticServiceProvider.GetService<IMapper>();
            AccountDTO accDto = _modelDto.MappingAccount<AccountNormalDTO>();             
            Account account = _mapper.Map<AccNormal>(accDto);
            return account;
        }
    }

    public class AccountEmailFactory : CreateAccountFactory
    {
        public AccountPOSTDTO _modelDto { get; set; }
        public AccountEmailFactory(AccountPOSTDTO model)
        {
            _modelDto = model;
            _modelDto.AccountTypeObj = JsonSerializer.Deserialize<AccountEmailDTO>(_modelDto.AccountTypeObj.ToString());
            _modelDto.GuidAccount = Guid.NewGuid();
        }
        protected override Account MakeAccount()
        {
            IMapper _mapper = StaticServiceProvider.GetService<IMapper>();
            AccountDTO accDto = _modelDto.MappingAccount<AccountEmailDTO>();
            Account account = _mapper.Map<AccEmailAssociated>(accDto);
            return account;
        }
    }

    public class AccountWebSiteFactory : CreateAccountFactory
    {
        public AccountPOSTDTO _modelDto { get; set; }
        public AccountWebSiteFactory(AccountPOSTDTO model)
        {
            _modelDto = model;
            _modelDto.AccountTypeObj = JsonSerializer.Deserialize<AccountWebAssociatedDTO>(_modelDto.AccountTypeObj.ToString());
            _modelDto.GuidAccount = Guid.NewGuid();
        }
        protected override Account MakeAccount()
        {
            IMapper _mapper = StaticServiceProvider.GetService<IMapper>();
            AccountDTO accDto = _modelDto.MappingAccount<AccountWebAssociatedDTO>();
            Account account = _mapper.Map<AccWebSite>(accDto);
            return account;
        }
    }

    public class AccountCardFactory : CreateAccountFactory
    {
        public AccountPOSTDTO _modelDto { get; set; }
        public AccountCardFactory(AccountPOSTDTO model)
        {
            _modelDto = model;
            _modelDto.AccountTypeObj = JsonSerializer.Deserialize<AccountCardDTO>(_modelDto.AccountTypeObj.ToString());
            _modelDto.GuidAccount = Guid.NewGuid();     
        }
        protected override Account MakeAccount()
        {
            IMapper _mapper = StaticServiceProvider.GetService<IMapper>();
            AccountDTO accDto = _modelDto.MappingAccount<AccountCardDTO>();
            Account account = _mapper.Map<AccCard>(accDto);
            return account;
        }
    }

    public static class AccountFactory
    {
        public static Account CreateAccountObject(AccountPOSTDTO accountModelDTO)
        {
            Account _account = accountModelDTO.CodeAccountType switch
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
