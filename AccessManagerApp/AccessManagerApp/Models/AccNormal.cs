namespace AccessManagerApp.Models
{
    public class AccNormal:Account
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Account Account { get; set; }
    }
}
