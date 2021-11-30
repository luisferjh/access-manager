using System.ComponentModel.DataAnnotations.Schema;

namespace AccessManagerApp.Models
{
    [Table("AccNormal")]
    public class AccNormal:Account
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
      
    }
}
