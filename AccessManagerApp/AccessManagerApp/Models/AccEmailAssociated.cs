using System.ComponentModel.DataAnnotations.Schema;

namespace AccessManagerApp.Models
{
    [Table("AccWebAssociated")]
    public class AccEmailAssociated:Account
    {
        public string Email { get; set; }
        
    }
}
