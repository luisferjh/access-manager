using System;

namespace AccessManagerApp.Models
{
    public class Account
    {
        public int IdAccount { get; set; }
        public int IdAccountType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }
        public DateTime CreationDate { get; set; }

        public AccountType AccountType { get; set; }
        public AccNormal AccNormal { get; set; }
        public AccWebSite AccWebSite { get; set; }
        public AccEmailAssociated AccEmailAssociated { get; set; }
        public AccCard AccCard { get; set; }
    }
}
