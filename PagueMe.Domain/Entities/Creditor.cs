namespace PagueMe.Domain.Entities
{
    public class Creditor
    {
        public int CreditorId { get; set; }
        public string Name { get; set; }
        public float Balance { get; set; }
        public string IdentityNumber { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public List<Loan> Loans { get; set; }
    }
}
