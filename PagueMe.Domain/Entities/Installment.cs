namespace PagueMe.Domain.Entities
{
    public class Installment
    {
        public int InstallmentsOrder { get; set; }
        public int Value { get; set; }
        public int LoanId { get; set; }
        public DateTime DueDate { get; set; }
        public int StatusPayment { get; set; }

        public float Interest {  get; set; }

        public Installment(int installmentsOrder, int value, String dueDate, int statusPayment,float interest)
        {
            InstallmentsOrder = installmentsOrder;
            Value = value;
            DueDate = DateTime.Parse(dueDate);
            StatusPayment = statusPayment;
            Interest = interest;
        }

    }
}
