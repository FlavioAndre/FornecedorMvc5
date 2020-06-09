using Fornecedor.Domain.Entities;
using Fornecedor.Domain.Interfaces;
using Fornecedor.Domain.Interfaces.Specification;

namespace Fornecedor.Domain.Specifications.Empresas
{
    class FornecedorDeveTerCnpjUnicoSpecification : ISpecification<Fornecedor>
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorDeveTerCnpjUnicoSpecification(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public bool IsSatisfiedBy(Fornecedor fornecedor)
        {
            return _fornecedorRepository.ObterPorCpfOuCnpj(fornecedor.CpfOuCnpj) == null;
        }
    }

}
