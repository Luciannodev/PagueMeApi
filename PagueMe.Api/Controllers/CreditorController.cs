using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pagame.Api.Dtos;
using Pagame.Api.Mapper;
using PagueMe.Application.Interfaces;
using PagueMe.Domain.Entities;

namespace PagueMe.Api.Controllers
{
    [ApiController]
    public class CreditorController(ICreditorUseCase creditorUsecase,IMapper mapper) : ControllerBase
    {

        private readonly ICreditorUseCase _CreditorUsecase = creditorUsecase;
        private readonly IMapper _Mapper = mapper;

        [HttpPost("register")]
        public ActionResult<Creditor> RegisterCreditor(CreditorRequestDTO creditorRequestDTO)
        {
            Creditor creditorEntity = _Mapper.Map<Creditor>(creditorRequestDTO);
            Creditor registedCreditor = _CreditorUsecase.CreateCreditor(creditorEntity);
            return new ActionResult<Creditor>(registedCreditor);
        }
    }
}
