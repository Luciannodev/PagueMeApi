namespace PagueMe.Domain.Entities
{
    public class Creditor
    {
        public int CreditorId { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; }
        public string IdentityNumber { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public List<Loan> Loans { get; set; }

        public Creditor() { }
      
        public Creditor(string name, int balance, string identityNumber, string password, string email, List<Loan> loans)
        {
            Name = name;
            Balance = balance;
            IdentityNumber = identityNumber;
            Password = password;
            Email = email;
            Loans = loans;
        }
    }
}
