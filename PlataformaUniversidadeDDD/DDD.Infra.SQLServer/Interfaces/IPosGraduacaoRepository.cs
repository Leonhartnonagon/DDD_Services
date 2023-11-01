using DDD.Domain.PosGraduacaoContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface IPosGraduacaoRepository
    {
        public PosGraduacao InsertPosGraduacao(int idProjeto, int idPesquisador);
        public List<PosGraduacao> GetPosGraduacoes();
        public PosGraduacao GetPosGraduacaoById(int id);
    }
}
