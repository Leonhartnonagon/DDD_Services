using DDD.Domain.PicContext;
using DDD.Infra.SQLServer.Interfaces;

namespace DDD.Infra.SQLServer.Repositories
{
    public class ProjetoRepositorySqlServer : IProjetoRepository
    {
        private readonly SqlContext _context;

        public ProjetoRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }

        public List<Projeto> GetProjeto()
        {
            return _context.Projetos.ToList();
        }

        public Projeto GetProjetoById(int id)
        {
            return _context.Projetos.Find(id);
        }

        public Projeto InsertProjeto(Projeto projeto)
        {
            try
            {
                _context.Projetos.Add(projeto);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                //log exception

            }

            return projeto;
        }
    }
}
