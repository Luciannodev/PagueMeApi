using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pagame.Api.Dtos;
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
        public ActionResult RegisterCreditor(CreditorRequestDTO creditorRequestDTO)
        {
            try
            {
                Creditor creditorEntity = _Mapper.Map<Creditor>(creditorRequestDTO);
                _CreditorUsecase.CreateCreditor(creditorEntity);
                return Content("Seu Cadastro foi Realizado Com Sucesso");
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possivel Cadastrar o Usuario");
            }

        }
    }
}
