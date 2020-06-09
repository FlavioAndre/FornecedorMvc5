using Fornecedor.Domain.Entities;
using Fornecedor.Domain.Interfaces.Specification;
using Fornecedor.Domain.Validations.Documentos;

namespace Fornecedor.Domain.Specifications.Empresas
{
    class EmpresaDeveTerCnpjValidoSpecification : ISpecification<Empresa>
    {
        public bool IsSatisfiedBy(Empresa empresa)
        {
            return CNPJValidation.Validar(empresa.CNPJ);
        }
    }

}
