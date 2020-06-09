using Fornecedor.Domain.Entities;
using Fornecedor.Domain.Interfaces.Specification;
using System;

namespace Fornecedor.Domain.Specifications.Fornecedores
{
    class FornecedorDeveTerUmaEmpresaSpecification : ISpecification<Fornecedor>
    {
        public bool IsSatisfiedBy(Fornecedor fornecedor)
        {
            return !(fornecedor.EmpresaId == Guid.Empty);
        }
    }
}
