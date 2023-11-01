using DDD.Domain.PicContext;
using DDD.Infra.SQLServer.Interfaces;

namespace DDD.Infra.SQLServer.Repositories
{
    public class PesquisadorRepositorySqlServer : IPesquisadorRepository
    {
        private readonly SqlContext _context;

        public PesquisadorRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }

        public List<Pesquisador> GetPesquisadores()
        {
            return _context.Pesquisadores.ToList();
        }

        Pesquisador IPesquisadorRepository.GetPesquisadorById(int id)
        {
            return _context.Pesquisadores.Find(id);
        }

        public void InsertPesquisador(Pesquisador pesquisador)
        {
            try
            {
                _context.Pesquisadores.Add(pesquisador);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                //log exception

            }
        }
    }
}
