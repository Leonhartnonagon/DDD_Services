using DDD.Domain.PicContext;
using DDD.Domain.SecretariaContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        readonly IProjetoIRepository _projetoRepository;

        public ProjetoController(IProjetoIRepository projetoIRepository)
        {
            _projetoRepository = projetoIRepository;
        }

        // GET
        [HttpGet]
        public ActionResult<List<Projeto>> Get()
        {
            return Ok(_projetoRepository.GetProjeto());
        }

        [HttpGet("{id}")]
        public ActionResult<Aluno> GetById(int id)
        {
            return Ok(_projetoRepository.GetProjetoById(id));
        }


        //Insert
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Projeto> InsertProjeto(Projeto projeto) 
        {
            if (projeto.AnosDuracao < 1)
            {
                return BadRequest("O projeto deve ter mais de 1 ano de duração.");
            }
            _projetoRepository.InsertProjeto(projeto);
            return CreatedAtAction(nameof(GetById), new { id = projeto.ProjetoId }, projeto);
        }
    }
}
