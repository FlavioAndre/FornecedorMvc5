using Fornecedor.Domain.Entities;
using Fornecedor.Domain.Interfaces.Repository;
using Fornecedor.Domain.Interfaces.Specification;

namespace Fornecedor.Domain.Specifications.Empresas
{
    class EmpresaDeveTerCnpjUnicoSpecification : ISpecification<Empresa>
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaDeveTerCnpjUnicoSpecification(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public bool IsSatisfiedBy(Empresa empresa)
        {
            return _empresaRepository.ObterPorCnpj(empresa.CNPJ) == null;
        }
    }

}
