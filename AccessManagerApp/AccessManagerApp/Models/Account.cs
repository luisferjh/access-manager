using System;
using System.Collections.Generic;

namespace AccessManagerApp.Models
{
    public abstract class Account
    {
        public int IdAccount { get; set; }
        public int IdAccountType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }
        public DateTime CreationDate { get; set; }

        public AccountType AccountType { get; set; }
        public List<AccountDetails> AccountDetails { get; set; }

    }
}
