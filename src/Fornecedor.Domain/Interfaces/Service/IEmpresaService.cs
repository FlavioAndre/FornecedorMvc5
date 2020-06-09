using System;
using System.Collections.Generic;
using Fornecedor.Domain.DTO;
using Fornecedor.Domain.Entities;

namespace Fornecedor.Domain.Interfaces.Service
{
    public interface IEmpresaService : IDisposable
    {
        Paged<Empresa> ObterTodos(string nome, int pageSize, int pageNumber);
        IEnumerable<Empresa> ObterTodos();
        Empresa Adicionar(Empresa empresa);
        Empresa ObterPorId(Guid id);

        Empresa Atualizar(Empresa empresa);
        void Remover(Guid id);
    }
}