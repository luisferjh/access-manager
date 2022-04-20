using System.ComponentModel.DataAnnotations;

namespace AccessManagerApp.DTOs
{
    public class UserLoginDTO
    {
        [Required(ErrorMessage = "Please enter username")]
        public string Username { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Password must not have more than 30 characters")]
        public string Password { get; set; }
    }
}
