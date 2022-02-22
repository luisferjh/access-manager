using AccessManagerApp.Data;
using AccessManagerApp.DTOs;
using AccessManagerApp.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AccessManagerApp.Services
{
    public class AccountTypeService
    {
        private readonly DbContextAccessManager _dbcontextAccessManager;
        private readonly IMapper _mapper;
        public AccountTypeService(DbContextAccessManager dbcontextAccessManager)
        {
         _dbcontextAccessManager = dbcontextAccessManager;
        }

        public async Task<AccountTypeDTO> GetAccount(string typeCode) 
        {
            AccountType result = await _dbcontextAccessManager.AccountTypes.FirstOrDefaultAsync(f => f.Code == typeCode);
            AccountTypeDTO type = _mapper.Map<AccountTypeDTO>(result);
            return type;
        }
    }
}
