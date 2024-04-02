namespace PagueMe.Domain.Entities
{
    public class Debtor(string name, String identityNumber)
    {
        public int DebtorId { get; set; }
        public String Name { get; set; } = name;
        public String IdentityNumber { get; set; } = identityNumber;
        public List<Loan> Loans { get; set; }
    }


}
