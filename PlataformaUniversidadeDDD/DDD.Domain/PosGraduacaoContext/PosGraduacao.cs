using DDD.Domain.SecretariaContext;
using DDD.Domain.PicContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.PosGraduacaoContext
{
    public class PosGraduacao
    {
        public int PosGradId { get; set; }

        public int PesquisadorId { get; set; }
        public Pesquisador Pesquisador { get; set; }

        public int ProjetoId { get; set; }
        public Projeto Projeto { get; set; }
    }
}
