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

        public  Creditor Creditor { get; set; }

        public  Debtor Debtor { get; set; }

        public float Interest {  get; set; }

        public float LoanValue {  get; set; }

        public  List<Installment> Installments { get; set; }

        public Loan()
        {
            
        }
        public Loan(float totalValue, int paymentStatus, int creditorId, int debtorId, String dueDate, Creditor creditor, Debtor debtor, float interest, float loanValue, List<Installment> installments)
        {
            TotalValue = totalValue;
            PaymentStatus = paymentStatus;
            CreditorId = creditorId;
            DebtorId = debtorId;
            DueDate = DateTime.Parse(dueDate);
            Creditor = creditor;
            Debtor = debtor;
            Interest = interest;
            LoanValue = loanValue;
            Installments = installments;
        }
    }
}
