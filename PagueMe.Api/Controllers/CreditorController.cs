using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PagueMe.Api.Dtos.Request;
using PagueMe.Api.Mapper;
using PagueMe.Application.Interfaces;
using PagueMe.Domain.Entities;

namespace PagueMe.Api.Controllers
{
    [ApiController]
    public class CreditorController: ControllerBase
    {

        private readonly ICreditorUseCase _CreditorUsecase ;
        private readonly DtoToEntityHelper _DtoToEntityHelper ;

        public CreditorController(ICreditorUseCase creditorUsecase,IMapper mapper)
        {
            _CreditorUsecase = creditorUsecase;
            _DtoToEntityHelper = new DtoToEntityHelper(mapper);
        }

        [HttpPost("register")]
        public ActionResult RegisterCreditor(CreditorRequestDTO creditorRequestDTO)
        {
            try
            {
                Creditor creditorEntity = _DtoToEntityHelper.DtoToEntity(creditorRequestDTO);
                _CreditorUsecase.CreateCreditor(creditorEntity);
                return Content("Seu Cadastro foi Realizado Com Sucesso");
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possivel Cadastrar o Usuario{ex}");
            }

        }


    }
}
