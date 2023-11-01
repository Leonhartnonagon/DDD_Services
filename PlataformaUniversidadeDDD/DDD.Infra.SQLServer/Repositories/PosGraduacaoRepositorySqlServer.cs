using DDD.Domain.PosGraduacaoContext;
using DDD.Domain.SecretariaContext;
using DDD.Infra.SQLServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Repositories
{
    public class PosGraduacaoRepositorySqlServer : IPosGraduacaoRepository
    {
        private readonly SqlContext _context;

        public PosGraduacaoRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }

        public PosGraduacao InsertPosGraduacao(int idProjeto, int idPesquisador)
        {
            var pesquisador = _context.Pesquisadores.First(i => i.UserId == idPesquisador);
            var projeto = _context.Projetos.First(i => i.ProjetoId == idProjeto);

            var posGrad = new PosGraduacao
            {
                Pesquisador = pesquisador,
                Projeto = projeto
            };

            try
            {

                _context.Add(posGrad);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                var msg = ex.InnerException;
                throw;
            }

            return posGrad;
        }
        public List<PosGraduacao> GetPosGraduacoes()
        {
            return _context.PosGraduacoes.ToList();
        }

        public PosGraduacao GetPosGraduacaoById(int id)
        {
            return _context.PosGraduacoes.Find(id);
        }
    }
}
