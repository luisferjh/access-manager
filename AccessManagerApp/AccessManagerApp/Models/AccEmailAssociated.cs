namespace AccessManagerApp.Models
{
    public class AccEmailAssociated:Account
    {
        public string Email { get; set; }

        public Account Account { get; set; }
    }
}
