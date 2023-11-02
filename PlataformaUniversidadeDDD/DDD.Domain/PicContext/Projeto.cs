namespace DDD.Domain.PicContext
{
    public class Projeto
    {
        public int ProjetoId { get; set; }
        public string ProjetoName { get;set; }
        public string ProjetoDescription { get; set; }
        public int AnosDuracao { get; set; }
        public List<Pesquisador>? Pesquisadores { get; set; }
    }
}
