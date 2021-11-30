using System.ComponentModel.DataAnnotations.Schema;

namespace AccessManagerApp.Models
{
    [Table("AccWebSite")]
    public class AccWebSite : Account
    {
        public string WebSiteName { get; set; }
       
    }
}
