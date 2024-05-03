namespace PagueMe.Domain.Entities
{
    public class Installment
    {
        public int InstallmentsOrder { get; set; }
        public float Value { get; set; }
        public int LoanId { get; set; }
        public DateTime DueDate { get; set; }
        public int PaymentStatus { get; set; }
        public Loan Loan { get; set; }
        public float Interest { get; set; } 


    }
}
