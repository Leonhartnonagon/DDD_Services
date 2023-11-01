using DDD.Domain.PicContext;
using DDD.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Application.Service
{
    public class ApplicationServiceProjeto
    {
        readonly ProjetoService _projetoService;

        public ApplicationServiceProjeto(ProjetoService projetoService)
        {
            _projetoService = projetoService;
        }

        public void CadastrarProjeto(Projeto projeto, int idPesquisador)
        {
            var projetoCadastrado = _projetoService.CadastrarProjeto(projeto, idPesquisador);
            if (projetoCadastrado)
            {
                //Enviar Confirmação do cadastro
            }
        }
    }
}
