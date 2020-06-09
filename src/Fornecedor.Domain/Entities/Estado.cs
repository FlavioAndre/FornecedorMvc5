namespace Fornecedor.Domain.Entities
{
    public class Estado
    {
        protected Estado()
        {
        }

        public Estado(string uf, string nome)
        {
            Nome = nome;
            Uf = uf;
        }

        public string Uf { get; set; }

        public string Nome { get; set; }
    }
}