using System;

namespace AccessManagerApp.DTOs
{
    public class JwtTokenSettingsDTO
    {
        public string token { get; set; }
        public DateTime ExpireTime { get; set; }
    }
}
