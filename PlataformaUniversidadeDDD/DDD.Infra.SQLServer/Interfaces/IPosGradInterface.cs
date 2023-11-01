using DDD.Domain.PosGraduacaoContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface IPosGradInterface
    {
        public PosGraduacao InsertPosGraduacao(int idProjeto, int idPesquisador);
        public PosGraduacao GetPosGraduacao(int idProjeto, int idPesquisador);
    }
}
