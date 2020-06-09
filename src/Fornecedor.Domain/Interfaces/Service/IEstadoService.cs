using System;
using System.Collections.Generic;
using Fornecedor.Domain.Entities;

namespace Fornecedor.Domain.Interfaces.Service
{
    public interface IEstadoService : IDisposable
    {
        IEnumerable<Estado> ObterTodos();
    }
}