using Pagame.Api.Dtos;
using Pagame.Api.Dtos.Enum;
using PagueMe.Domain.Entities;
using PagueMe.Domain.Repositories;
using System.Collections.Generic;

namespace Pagame.Api.Mapper
{
    public class LoanMapper
    {
        private readonly ICreditorRepository _creditorRepository;

        public LoanMapper(ICreditorRepository creditorRepository)
        {
            _creditorRepository = creditorRepository;
        }

        public Loan DtotoEntity(LoanRequestDTO loanRequest)
        {

            List<Installment> installments = [];

            List<InstallmentDTO> installmentsDTO = loanRequest.Installment;

            installmentsDTO.ForEach(installment =>
            {
                installments.Add(new Installment(installment.OrdemParcela, installment.Value, installment.DataVencimento, (int)StatusPaymentEnum.pending, loanRequest.Interest));
            });

            Creditor creditor = _creditorRepository.GetLoanByIdentityNumber("13731581744");
            var debtor = new Debtor(loanRequest.Name, loanRequest.IdentityNumber);
            Loan loan = new Loan(loanRequest.TotalValue, (int)StatusPaymentEnum.pending, creditor.CreditorId, debtor.DebtorId, loanRequest.DueDate, creditor, debtor,
            loanRequest.Interest, loanRequest.LoanValue, installments);
            return loan;
        }
    }
}
