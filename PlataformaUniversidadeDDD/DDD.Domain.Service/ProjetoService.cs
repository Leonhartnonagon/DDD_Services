using DDD.Domain.PicContext;
using DDD.Domain.PicContext.Enums;
using DDD.Infra.SQLServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Service
{
    public class ProjetoService
    {
        readonly IPesquisadorRepository _pesquisadorRepository;
        readonly IProjetoRepository _projetoRepository;
        readonly IPosGraduacaoRepository _posGraduacaoRepository;

        public ProjetoService(IPesquisadorRepository pesquisadorRepository, IProjetoRepository projetoRepository, IPosGraduacaoRepository posGraduacaoRepository)
        {
            _pesquisadorRepository = pesquisadorRepository;
            _projetoRepository = projetoRepository;
            _posGraduacaoRepository = posGraduacaoRepository;
        }

        public bool CadastrarProjeto(Projeto projeto, int idPesquisador)
        {
            try
            {
                if(projeto.AnosDuracao > 1)
                {
                    var pesquisador = _pesquisadorRepository.GetPesquisadorById(idPesquisador);
                    if (pesquisador.Titulacao != TitulacaoPesquisador.Mestre || pesquisador.Titulacao != TitulacaoPesquisador.Doutor)
                    {
                       var projetoCadastrado = _projetoRepository.InsertProjeto(projeto);

                        if (projetoCadastrado != null)
                        {
                            _posGraduacaoRepository.InsertPosGraduacao(projeto.ProjetoId, idPesquisador);
                        }
                    }

                }
                return true;
            }
            catch (Exception ex)
            {
                var erro = ex.Message;
                throw;
            }
        }
        }
    }
