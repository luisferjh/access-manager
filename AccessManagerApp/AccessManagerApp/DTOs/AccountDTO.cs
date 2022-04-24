using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AccessManagerApp.DTOs
{
    public class AccountDTO
    {
        public int IdAccount { get; set; }
        public int IdUser { get; set; }
        public int IdAccountType { get; set; }
        public string CodeAccountType { get; set; }

        [JsonConverter(typeof(string))]
        public Guid GuidAccount { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }
        public DateTime CreationDate { get; set; }
    }


    public class AccountPOSTDTO
    {
        public int IdAccount { get; set; }
        public int IdUser { get; set; }
        public int IdAccountType { get; set; }
        public string CodeAccountType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }
        public DateTime CreationDate { get; set; }
        public object AccountTypeObj { get; set; }
        public List<AccountDetailDTO> Details { get; set; }
    }

    public class AccountDetailDTO 
    {
        public int IdAccountDetail { get; set; }
        public int IdAccount { get; set; }
        public string TagName { get; set; }
        public string ValueTag { get; set; }
        public bool IsSensitive { get; set; }
        public bool State { get; set; }
    }

    public class AccountNormalDTO: AccountDTO
    {       
        public string UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class AccountEmailDTO: AccountDTO
    {       
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
       
    }

    public class AccountWebAssociatedDTO: AccountDTO
    {
        [StringLength(50, ErrorMessage = "web site must not have more than 50 characters.")]
        public string WebSiteName { get; set; }

    }

    public class AccountCardDTO: AccountDTO
    {       
        public string CarType { get; set; }
        public string Franchise { get; set; }
        public string Bank { get; set; }
        public string CCV { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }

}
