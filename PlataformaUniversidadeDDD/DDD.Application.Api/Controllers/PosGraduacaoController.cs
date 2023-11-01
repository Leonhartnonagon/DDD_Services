using DDD.Domain.PosGraduacaoContext;
using DDD.Domain.PicContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PosGraduacaoController : ControllerBase
    {
        readonly IPosGraduacaoRepository _posGraduacaoRepository;

        public PosGraduacaoController(IPosGraduacaoRepository posGraduacaoRepository)
        {
            _posGraduacaoRepository = posGraduacaoRepository; 
        }

        [HttpGet]
        public ActionResult<List<PosGraduacao>> Get()
        {
            return Ok(_posGraduacaoRepository.GetPosGraduacoes());
        }

        [HttpGet("{id}")]
        public ActionResult<Pesquisador> GetById(int id)
        {
            return Ok(_posGraduacaoRepository.GetPosGraduacaoById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<PosGraduacao> CreatePosGraduacao(int idPesquisador, int idProjeto)
        {
            PosGraduacao posGraduacaoIdSaved = _posGraduacaoRepository.InsertPosGraduacao(idPesquisador, idProjeto);
            return CreatedAtAction(nameof(GetById), new { id = posGraduacaoIdSaved.PosGradId }, posGraduacaoIdSaved);
        }

    }
}
