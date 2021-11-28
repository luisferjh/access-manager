using System.Collections.Generic;

namespace AccessManagerApp.Models
{
    public class AccountType
    {
        public int IdAccountType { get; set; }
        public string Code { get; set; }
        public string TypeName { get; set; }


        public List<Account> Account { get; set; } = new List<Account>();
    }
}
