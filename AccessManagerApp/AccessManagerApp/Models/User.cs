using System;
using System.Collections.Generic;

namespace AccessManagerApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime Created { get; set; }
        public bool State { get; set; }


        public List<Account> Accounts { get; set; } = new List<Account>();

    }
}
