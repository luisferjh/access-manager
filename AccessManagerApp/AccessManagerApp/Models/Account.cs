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
    }
}
