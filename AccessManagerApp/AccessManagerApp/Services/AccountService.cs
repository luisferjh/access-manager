using AccessManagerApp.Data;
using AccessManagerApp.DTOs;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using AccessManagerApp.Models;
using AutoMapper;
using AccessManagerApp.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace AccessManagerApp.Services
{
    public class AccountService
    {
        private readonly DbContextAccessManager _dbContextAccessManager;
        private readonly IMapper _mapper;
        public AccountService(DbContextAccessManager dbContextAccessManager, IMapper mapper)
        {
            _dbContextAccessManager = dbContextAccessManager;
            _mapper = mapper;
        }

        public async Task<AccountDTO> GetAccount(string _guid) 
        {
            Guid guid = Guid.Parse(_guid);
            Account account = await _dbContextAccessManager.Accounts.FirstOrDefaultAsync(f => f.GuidAccount == guid);
            AccountDTO accountDTO = _mapper.Map<AccountDTO>(account);
            return accountDTO;
        }

        public async Task<List<AccountDetailDTO>> GetDetailAccount(string _guid)
        {
            Guid guid = Guid.Parse(_guid);
            IEnumerable<AccountDetails> details;
            List<AccountDetailDTO> detailsDto;
            Account account = await _dbContextAccessManager.Accounts.FirstOrDefaultAsync(f => f.GuidAccount == guid);
            if (account != null)
            {
                details = _dbContextAccessManager.AccountDetails
                   .Where(f => f.IdAccount == account.IdAccount)
                   .ToList();
                detailsDto = _mapper.Map<List<AccountDetailDTO>>(details);
                return detailsDto;
            }
            else 
            {
                return detailsDto = null;
            }                       
        }

        public async Task<bool> SaveAccountAsync(AccountPOSTDTO model)
        {
            try
            {                            
                AccountDTO accountDto = AccountFactory.CreateAccountObject(model);
                Account account = _mapper.Map<Account>(accountDto);
                account.GuidAccount = Guid.NewGuid();
                using (var transaction = _dbContextAccessManager.Database.BeginTransaction())
                {
                    _dbContextAccessManager.Accounts.Add(account);
                    await SaveChangesAsync();

                    if (model.Details != null && model.Details.Count > 0)
                    {                    
                        List<AccountDetails> accountDetails = _mapper.Map<List<AccountDetails>>(model.Details);
                        accountDetails.ForEach(f => {
                            f.IdAccount = account.IdAccount;                          
                        });

                        _dbContextAccessManager.AccountDetails.AddRange(accountDetails);
                        await SaveChangesAsync();
                    }                                     
                    _dbContextAccessManager.Database.CommitTransaction();
                }               
            }
            catch (Exception ex)
            {
                _dbContextAccessManager.Database.RollbackTransaction();
                throw;
            }
            return true;
        }

        public async Task<bool> SaveAccountDetailsAsync(List<AccountDetailDTO> model)
        {           
            List<AccountDetails> accountDetails = _mapper.Map<List<AccountDetails>>(model);
            await _dbContextAccessManager.AccountDetails.AddRangeAsync(accountDetails);            
            bool result = await SaveChangesAsync();
            return result;
        }

        public async Task<bool> UpdateAccountAsync(AccountPOSTDTO model)
        {           
            AccountDTO accountDto = AccountFactory.CreateAccountObject(model);        
            Account account = await _dbContextAccessManager.Accounts.FirstOrDefaultAsync(f => f.GuidAccount == accountDto.GuidAccount);
            if (account == null)
                return false;

            account = _mapper.Map<Account>(accountDto);              
            bool result = await SaveChangesAsync();                                             
            return result;
        }


        public async Task<bool> UpdateAccountDetailAsync(AccountDetailDTO model) 
        {
            AccountDetails accountDetail = await _dbContextAccessManager.AccountDetails.FirstOrDefaultAsync(f => f.IdAccountDetail == model.IdAccountDetail);
            accountDetail = _mapper.Map<AccountDetails>(accountDetail);
            bool result = await SaveChangesAsync();
            return result;
        }

        public async Task<bool> SaveChangesAsync()         
            => await _dbContextAccessManager.SaveChangesAsync() >= 0;

        
    }   

}
