using DDD.Domain.PicContext;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface IPesquisadorRepository
    {
        public void InsertPesquisador(Pesquisador pesquisador);
        public List<Pesquisador> GetPesquisadores();
        public Pesquisador GetPesquisadorById(int id);
    }
}
