using Fornecedor.Domain.Entities;
using Fornecedor.Domain.Interfaces.Specification;
using System.Linq;

namespace Fornecedor.Domain.Specifications.Fornecedores
{
    class FornecedorDeveTerUmTelefoneSpecification : ISpecification<Fornecedor>
    {
        public bool IsSatisfiedBy(Fornecedor fornecedor)
        {
            return fornecedor.Telefones != null && fornecedor.Telefones.Any();
        }
    }
}
