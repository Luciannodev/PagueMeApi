namespace PagueMe.Domain.Entities
{
    public class Debtor
    {
        public int DebtorId { get; set; }
        public string Name { get; set; }
        public string ?IdentityNumber { get; set; }
        public List<Loan> Loans { get; set; }
    }


}
