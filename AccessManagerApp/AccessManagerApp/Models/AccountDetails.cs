namespace AccessManagerApp.Models
{
    public class AccountDetails
    {
        public int IdAccountDetail { get; set; }
        public int IdAccount { get; set; }
        public string TagName { get; set; }
        public string ValueTag { get; set; }
        public bool IsSensitive { get; set; }
        public bool State { get; set; }

        public Account Account { get; set; }
    }
}
