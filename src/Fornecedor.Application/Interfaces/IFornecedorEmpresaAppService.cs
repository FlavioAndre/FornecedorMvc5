using System;
using System.Collections.Generic;
using Fornecedor.Application.ViewModels;

namespace Fornecedor.Application.Interfaces
{
    public interface IFornecedorEmpresaAppService : IDisposable
    {
        PagedViewModel<EmpresaViewModel> ObterEmpresaTodos(string nome, int pageSize, int pageNumber);

        PagedViewModel<FornecedorViewModel> ObterFornecedorTodos(string nome, int pageSize, int pageNumber);
        IEnumerable<EstadoViewModel> ObeterEstadoTodos();

        FornecedorTelefoneViewModel ObterFornecedorPorId(Guid id);
        FornecedorTelefoneViewModel AdicionarFornecedor(FornecedorTelefoneViewModel fornecedorViewModel);
        FornecedorTelefoneViewModel AtualizarFornecedor(FornecedorTelefoneViewModel fornecedorViewModel);
        void RemoverFornecedor(Guid id);

        EmpresaViewModel ObterEmpresaPorId(Guid id);
        EmpresaViewModel AdicionarEmpresa(EmpresaViewModel empresaViewModel);
        EmpresaViewModel AtualizarEmpresa(EmpresaViewModel empresaViewModel);
        void RemoverEmpresa(Guid id);
        IEnumerable<EmpresaViewModel> ObterEmpresaTodos();

        TelefoneViewModel AdicionarTelefone(TelefoneViewModel telefoneViewModel);
        TelefoneViewModel AtualizarTelefone(TelefoneViewModel telefoneViewModel);
        TelefoneViewModel ObterTelefonePorId(Guid id);
        void RemoverEndereco(Guid id);
    }
}