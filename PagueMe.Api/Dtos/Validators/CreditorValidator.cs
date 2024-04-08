using FluentValidation;
using Pagame.Api.Dtos;

namespace PagueMe.Api.Dtos.Vallidators
{
    public class CreditorValidator : AbstractValidator<CreditorRequestDTO>
    {
        public CreditorValidator()
        {
            RuleFor(x => x.Name).NotNull().MaximumLength(50).MinimumLength(6).WithMessage("Nome deve ser mais de 6 caracteres e menos de 50!");
            RuleFor(x=>x.Email).MaximumLength(50).EmailAddress().WithMessage("Email inválido!");
            RuleFor(x => x.Password).MinimumLength(6).MaximumLength(50).WithMessage("O Codigo deve ter no minimo 6 caracteres!");
            RuleFor(x => x.IdentityNumber).IsValidCPF().WithMessage("CPF inválido!");
        }
     
    }
}
