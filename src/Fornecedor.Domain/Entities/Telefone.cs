using System;

namespace Fornecedor.Domain.Entities
{
    public class Telefone
    {
        public Telefone()
        {
            TelefoneId = Guid.NewGuid();
        }

        public Guid TelefoneId { get; set; }

        public string Numero { get; set; }

        public Guid FornecedorId { get; set; }

        public virtual Fornecedor Fornecedor { get; set; }
    }
}