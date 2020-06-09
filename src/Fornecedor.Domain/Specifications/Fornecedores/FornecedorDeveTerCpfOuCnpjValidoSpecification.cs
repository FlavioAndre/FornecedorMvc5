using Fornecedor.Domain.Entities;
using Fornecedor.Domain.Interfaces.Specification;
using Fornecedor.Domain.Validations.Documentos;

namespace Fornecedor.Domain.Specifications.Empresas
{
    class FornecedorDeveTerCpfOuCnpjValidoSpecification : ISpecification<Fornecedor>
    {
        public bool IsSatisfiedBy(Fornecedor fornecedor)
        {
            if (fornecedor.TipoFornecedor == TipoPessoa.FISICA) return CPFValidation.Validar(fornecedor.CpfOuCnpj);
            return CNPJValidation.Validar(fornecedor.CpfOuCnpj);
        }
        
    }

}
