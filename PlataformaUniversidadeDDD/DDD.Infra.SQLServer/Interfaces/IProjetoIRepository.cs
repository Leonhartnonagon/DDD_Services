using DDD.Domain.PicContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface IProjetoIRepository
    {
        public void InsertProjeto(Projeto projeto);
        public List<Projeto> GetProjeto();
        public Projeto GetProjetoById(int id);
       
    }
}
