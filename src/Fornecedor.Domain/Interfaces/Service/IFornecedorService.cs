using System;
using Fornecedor.Domain.DTO;
using Fornecedor.Domain.Entities;

namespace Fornecedor.Domain.Interfaces.Service
{
    public interface IFornecedorService : IDisposable
    {
        Fornecedor Adicionar(Fornecedor cliente);
        Fornecedor ObterPorId(Guid id);

        Paged<Fornecedor> ObterTodos(string nome, int pageSize, int pageNumber);
        Fornecedor Atualizar(Fornecedor cliente);
        void Remover(Guid id);

        Telefone AdicionarTelefone(Telefone telefone);
        Telefone AtualizarTelefone(Telefone telefone);
        Telefone ObterTelefonePorId(Guid id);
        void RemoverTelefone(Guid id);
    }
}