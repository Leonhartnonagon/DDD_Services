using DDD.Application.Service;
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
        readonly IProjetoRepository _projetoRepository;
        readonly ApplicationServiceProjeto _projetoService;

        public ProjetoController(IProjetoRepository projetoIRepository)
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
        [Route("gerarBoletim")]
        
        public void CadastrarProjeto(Projeto projeto, int idPesquisador) 
        {
            
            _projetoService.CadastrarProjeto(projeto, idPesquisador);
            
        }
    }
}
