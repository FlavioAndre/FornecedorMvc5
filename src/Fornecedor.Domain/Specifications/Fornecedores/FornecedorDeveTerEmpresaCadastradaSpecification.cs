using Fornecedor.Domain.Entities;
using Fornecedor.Domain.Interfaces.Repository;
using Fornecedor.Domain.Interfaces.Specification;

namespace Fornecedor.Domain.Specifications.Fornecedores
{
    class FornecedorDeveTerEmpresaCadastradaSpecification : ISpecification<Fornecedor>
    {
        private readonly IEmpresaRepository _empresaRepository;

        public FornecedorDeveTerEmpresaCadastradaSpecification(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public bool IsSatisfiedBy(Fornecedor fornecedor)
        {
            return _empresaRepository.ObterPorId(fornecedor.EmpresaId) != null;
        }
    }
}
