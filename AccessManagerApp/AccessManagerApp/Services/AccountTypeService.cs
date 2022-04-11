using AccessManagerApp.Data;
using AccessManagerApp.DTOs;
using AccessManagerApp.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessManagerApp.Services
{
    public class AccountTypeService
    {
        private readonly DbContextAccessManager _dbcontextAccessManager;
        private readonly IMapper _mapper;
        public AccountTypeService(DbContextAccessManager dbcontextAccessManager, IMapper mapper)
        {
         _dbcontextAccessManager = dbcontextAccessManager;
            _mapper = mapper;
        }

        public async Task<AccountTypeDTO> GetTypeAccount(string typeCode) 
        {
            AccountType result = await _dbcontextAccessManager.AccountTypes.FirstOrDefaultAsync(f => f.Code == typeCode);

            if (result == null) 
            {               
                return null;            
            }

            AccountTypeDTO type = _mapper.Map<AccountTypeDTO>(result);
            return type;
        }

        public async Task<IEnumerable<AccountTypeDTO>> ListTypes() 
        {
            List<AccountType> list = await _dbcontextAccessManager.AccountTypes.ToListAsync();           

            List<AccountTypeDTO> result = _mapper.Map<List<AccountTypeDTO>>(list);           

            return result;
        }

        public async Task SaveTypeAccount(AccountTypeDTO model)
        {           
            AccountType result = _mapper.Map<AccountType>(model);
            await _dbcontextAccessManager.AccountTypes.AddAsync(result);
            await _dbcontextAccessManager.SaveChangesAsync();                      
        }

        public bool AccountTypeExist(string code) 
        {
            bool result = _dbcontextAccessManager.AccountTypes.Any(f => f.Code == code);
            return result;
        }

        public bool AccountTypeExist(int id)
        {
            bool result = _dbcontextAccessManager.AccountTypes.Any(f => f.IdAccountType == id);
            return result;
        }
    }
}
