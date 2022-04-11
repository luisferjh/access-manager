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

        public async Task<bool> SaveAccount(AccountPOSTDTO model)
        {
            try
            {                            
                Account result = AccountFactory.CreateAccountObject(model);
                using (var transaction = _dbContextAccessManager.Database.BeginTransaction())
                {
                    _dbContextAccessManager.Accounts.Add(result);
                    await SaveChangesAsync();

                    if (model.Details != null && model.Details.Count > 0)
                    {
                        List<AccountDetailDTO> DetailsDto = JsonSerializer.Deserialize<List<AccountDetailDTO>>(model.Details.ToString());
                        List<AccountDetails> accountDetails = _mapper.Map<List<AccountDetails>>(DetailsDto);
                        accountDetails.ForEach(f => {
                            f.IdAccount = result.IdAccount;                          
                        });

                        _dbContextAccessManager.AccountDetails.AddRange(accountDetails);
                        await SaveChangesAsync();
                    }                                     
                    _dbContextAccessManager.Database.CommitTransaction();
                }
               
            }
            catch (DbUpdateException ex)
            {
                _dbContextAccessManager.Database.RollbackTransaction();
                return false;
            }

            return true;
        }

        public async Task<bool> SaveChangesAsync()         
            => await _dbContextAccessManager.SaveChangesAsync() >= 0;

        
    }   

}
