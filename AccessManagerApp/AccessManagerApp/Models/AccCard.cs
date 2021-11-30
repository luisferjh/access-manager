using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccessManagerApp.Models
{
    [Table("AccCard")]
    public class AccCard : Account
    {
        public string CardType { get; set; }
        public string Franchise { get; set; }
        public string Bank { get; set; }
        public string CCV { get; set; }
        public DateTime ExpirationDate { get; set; }
       
    }
}
