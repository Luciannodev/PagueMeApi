namespace PagueMe.Domain.Entities
{
    public class Loan
    {
        public int LoanId { get; set; }
        public float TotalValue { get; set; }
        public int PaymentStatus { get; set; }
        public int CreditorId { get; set; }
        public int DebtorId { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime RegistrationDate { get; set; }

        public  Creditor ?Creditor { get; set; }

        public  Debtor ?Debtor { get; set; }

        public float Interest {  get; set; }

        public float LoanValue {  get; set; }

        public  List<Installment> ?Installment { get; set; }

    }
}
