using Microsoft.AspNetCore.Mvc;
using PagueMe.Api.Dtos.Request;
using PagueMe.Api.Mapper;
using PagueMe.Application.Interfaces;
using PagueMe.Domain.Entities;

namespace PagueMe.Api.Controllers
{
    [ApiController]
    public class CreditorController : ControllerBase
    {

        private readonly ICreditorUseCase _CreditorUsecase;

        public CreditorController(ICreditorUseCase creditorUsecase)
        {
            _CreditorUsecase = creditorUsecase;
        }

        [HttpPost("register")]
        public ActionResult RegisterCreditor(CreditorRequestDTO creditorRequestDTO)
        {
            try
            {
                Creditor creditorEntity = DtoToEntityHelper.CreditorDtoToEntity(creditorRequestDTO);
                _CreditorUsecase.CreateCreditor(creditorEntity);
                return Content("Seu Cadastro foi Realizado Com Sucesso");
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possivel Cadastrar o Usuario.{ex}");
            }

        }


    }
}
