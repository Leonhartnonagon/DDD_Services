using DDD.Application.Service;
using DDD.Domain.PicContext;
using DDD.Domain.SecretariaContext;
using DDD.Domain.Service;
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

        public ProjetoController(IProjetoRepository projetoIRepository, ApplicationServiceProjeto applicationServiceProjeto)
        {
            _projetoRepository = projetoIRepository;
            _projetoService = applicationServiceProjeto;
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
        [Route("CadastrarProjeto")]
        
        public void CadastrarProjeto(Projeto projeto, int idPesquisador) 
        {
            
            _projetoService.CadastrarProjeto(projeto, idPesquisador);
            
        }
    }
}
