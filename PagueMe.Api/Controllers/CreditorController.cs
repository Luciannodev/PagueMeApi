using Microsoft.AspNetCore.Mvc;
using Pagame.Api.Dtos;
using Pagame.Api.Mapper;
using PagueMe.Application.Interfaces;
using PagueMe.Domain.Entities;

namespace PagueMe.Api.Controllers
{
    [ApiController]
    public class CreditorController(ICreditorUseCase creditorUsecase) : ControllerBase
    {

        private readonly ICreditorUseCase _CreditorUsecase = creditorUsecase;

        [HttpPost("register")]
        public ActionResult<Creditor> RegisterCreditor(CreditorRequestDTO creditorRequestDTO)
        {
            Creditor creditorEntity = CreditorMapper.DtoToEntity(creditorRequestDTO);
            Creditor registedCreditor = _CreditorUsecase.CreateCreditor(creditorEntity);
            return new ActionResult<Creditor>(registedCreditor);
        }
    }
}
