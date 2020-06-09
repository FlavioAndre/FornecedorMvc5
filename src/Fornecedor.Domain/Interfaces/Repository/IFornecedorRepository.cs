using Fornecedor.Domain.DTO;
using Fornecedor.Domain.Entities;
using Fornecedor.Domain.Interfaces.Repository;

namespace Fornecedor.Domain.Interfaces
{
    public interface IFornecedorRepository : IRepository<Fornecedor>
    {
        Paged<Fornecedor> ObterTodos(string nome, int pageSize, int pageNumber);
        Fornecedor ObterPorCpfOuCnpj(string cpfOuCnpj);
        Fornecedor AtualizaFornecedorEndereco(Fornecedor fornecedor);
    }
}