using Fornecedor.Domain.DTO;
using Fornecedor.Domain.Entities;

namespace Fornecedor.Domain.Interfaces.Repository
{
    public interface IEmpresaRepository : IRepository<Empresa>
    {
        Paged<Empresa> ObterTodos(string nome, int pageSize, int pageNumber);
        Empresa ObterPorCnpj(string cnpj);
    }
}