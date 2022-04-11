using AccessManagerApp.DTOs;
using AccessManagerApp.Models;
using System.Text.Json;

namespace AccessManagerApp.Helpers
{
    public static class ExtensionsMethods
    {
        public static AccountDTO MappingAccount<T>(this AccountPOSTDTO accountDto) where T : AccountDTO
        {
            AccountDTO accountTypeDetail = (T)accountDto.AccountTypeObj;               

            accountTypeDetail.IdAccountType = accountDto.IdAccountType;
            accountTypeDetail.CodeAccountType = accountDto.CodeAccountType;
            accountTypeDetail.GuidAccount = accountDto.GuidAccount;
            accountTypeDetail.Name = accountDto.Name;
            accountTypeDetail.Description = accountDto.Description;
            accountTypeDetail.State = accountDto.State;
            accountTypeDetail.CreationDate = accountDto.CreationDate;

            return accountTypeDetail;

        }
    }
}
