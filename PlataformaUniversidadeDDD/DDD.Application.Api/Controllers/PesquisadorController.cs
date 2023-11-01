using DDD.Application.Service;
using DDD.Domain.PicContext;
using DDD.Domain.SecretariaContext;
using DDD.Domain.Service;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PesquisadorController : ControllerBase
    {
        readonly IPesquisadorRepository _pesquisadorRepository;

        public PesquisadorController(IPesquisadorRepository pesquisadorRepository)
        {
            _pesquisadorRepository = pesquisadorRepository;
        }

        // GET: api/<PesquisadorController>
        
        [HttpGet]
        public ActionResult<List<Aluno>> Get()
        {
            return Ok(_pesquisadorRepository.GetPesquisadores   );
        }

        [HttpGet("{id}")]
        public ActionResult<Aluno> GetById(int id)
        {
            return Ok(_pesquisadorRepository.GetPesquisadorById(id));
        }

        //insert pesquisador
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Pesquisador> InsertPesquisador(Pesquisador pesquisador)
        {
            if (pesquisador.Nome.Length < 3 || pesquisador.Nome.Length > 30)
            {
                return BadRequest("Nome deve ser maior que 3 e menor que 30 caracteres.");
            }
            _pesquisadorRepository.InsertPesquisador(pesquisador);
            return CreatedAtAction(nameof(GetById), new { id = pesquisador.UserId }, pesquisador);
        }


    }
}