using System;

namespace AccessManagerApp.Models
{
    public class AccCard : Account
    {
        public string CardType { get; set; }
        public string Franchise { get; set; }
        public string Bank { get; set; }
        public string CCV { get; set; }
        public DateTime ExpirationDate { get; set; }

        public Account Account { get; set; }
    }
}
