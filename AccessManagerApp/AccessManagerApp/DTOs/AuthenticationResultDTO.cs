using System.Collections.Generic;

namespace AccessManagerApp.DTOs
{
    public class AuthenticationResultDTO
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; } 
        public JwtTokenSettingsDTO JwtToken { get; set; }
    }

}
