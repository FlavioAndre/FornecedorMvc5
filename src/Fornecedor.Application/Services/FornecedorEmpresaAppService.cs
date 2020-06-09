using System;
using System.Collections.Generic;
using AutoMapper;
using Fornecedor.Application.AutoMapper;
using Fornecedor.Application.Interfaces;
using Fornecedor.Application.ViewModels;
using Fornecedor.Domain.Entities;
using Fornecedor.Domain.Interfaces.Service;
using Fornecedor.Infra.Data.Interfaces;

namespace Fornecedor.Application.Services
{
    public class FornecedorEmpresaAppService : ApplicationService, IFornecedorEmpresaAppService
    {
        private readonly IEmpresaService _empresaService;
        private readonly IEstadoService _estadoService;
        private readonly IFornecedorService _fornecedorService;
        private readonly IMapper _mapper;

        public FornecedorEmpresaAppService(IFornecedorService fornecedorService,
            IEmpresaService empresaService,
            IEstadoService estadoService,
            IUnitOfWork uow) : base(uow)
        {
            _mapper = AutoMapperConfig.Mapper;
            _fornecedorService = fornecedorService;
            _empresaService = empresaService;
            _estadoService = estadoService;
        }

        public EmpresaViewModel AdicionarEmpresa(EmpresaViewModel empresaViewModel)
        {
            var empresa = _mapper.Map<Empresa>(empresaViewModel);
            BeginTransaction();

            var empresaRetorno = _empresaService.Adicionar(_mapper.Map<Empresa>(empresaViewModel));
            empresaViewModel = _mapper.Map<EmpresaViewModel>(empresaRetorno);
            if (empresaRetorno.ValidationResult != null && !empresaRetorno.ValidationResult.IsValid)
            {
                return empresaViewModel;
            }

            Commit();
            return empresaViewModel;
        }

        public FornecedorTelefoneViewModel AdicionarFornecedor(FornecedorTelefoneViewModel fornecedorViewModel)
        {
            var fornecedor = _mapper.Map<Fornecedor>(fornecedorViewModel);
            var telefone = _mapper.Map<Telefone>(fornecedorViewModel);
            fornecedor.Telefones.Add(telefone);
            var telefoneViewModel = _mapper.Map<TelefoneViewModel>(telefone);
            fornecedorViewModel.Telefones.Add(telefoneViewModel);
            BeginTransaction();
            var fornecedorAdicionado = _fornecedorService.Adicionar(_mapper.Map<Fornecedor>(fornecedorViewModel));
            fornecedorViewModel = _mapper.Map<FornecedorTelefoneViewModel>(fornecedorAdicionado);
            if (fornecedorAdicionado.ValidationResult != null && !fornecedorAdicionado.ValidationResult.IsValid)
            {
                return fornecedorViewModel;
            }
            //_fornecedorService.AdicionarTelefone(telefone);

            Commit();


            return fornecedorViewModel;
        }

        public EmpresaViewModel AtualizarEmpresa(EmpresaViewModel empresaViewModel)
        {
            var empresa = _mapper.Map<Empresa>(empresaViewModel);
            BeginTransaction();
            
            var empresaRetorno =_empresaService.Atualizar(_mapper.Map<Empresa>(empresaViewModel));
            empresaViewModel = _mapper.Map<EmpresaViewModel>(empresaRetorno);
            if (empresaRetorno.ValidationResult != null && !empresaRetorno.ValidationResult.IsValid)
            {
                return empresaViewModel;
            }

            Commit();
            return empresaViewModel;
        }

        public FornecedorTelefoneViewModel AtualizarFornecedor(FornecedorTelefoneViewModel fornecedorViewModel)
        {
            var fornecedor = _mapper.Map<Fornecedor>(fornecedorViewModel);
            var telefone = _mapper.Map<Telefone>(fornecedorViewModel);
            telefone.Fornecedor = fornecedor;
            fornecedor.Telefones.Add(telefone);
            BeginTransaction();
            var fornecedorAdicionado = _fornecedorService.Atualizar(_mapper.Map<Fornecedor>(fornecedor));
            fornecedorViewModel = _mapper.Map<FornecedorTelefoneViewModel>(fornecedorAdicionado);
            if (fornecedorAdicionado.ValidationResult != null && !fornecedorAdicionado.ValidationResult.IsValid)
            {
                return fornecedorViewModel;
            }

            _fornecedorService.AdicionarTelefone(telefone);

            Commit();
            return fornecedorViewModel;
        }


        public IEnumerable<EstadoViewModel> ObeterEstadoTodos()
        {
            return _mapper.Map<IEnumerable<EstadoViewModel>>(_estadoService.ObterTodos());
        }

        public IEnumerable<EmpresaViewModel> ObterEmpresaTodos()
        {
            return _mapper.Map<IEnumerable<EmpresaViewModel>>(_empresaService.ObterTodos());
        }

        public EmpresaViewModel ObterEmpresaPorId(Guid id)
        {
            return _mapper.Map<EmpresaViewModel>(_empresaService.ObterPorId(id));
        }

        public PagedViewModel<EmpresaViewModel> ObterEmpresaTodos(string nome, int pageSize, int pageNumber)
        {
            return _mapper.Map<PagedViewModel<EmpresaViewModel>>(
                _empresaService.ObterTodos(nome, pageSize, pageNumber));
        }

        public FornecedorTelefoneViewModel ObterFornecedorPorId(Guid id)
        {
            var fornecedor = _fornecedorService.ObterPorId(id);
            return _mapper.Map<FornecedorTelefoneViewModel>(fornecedor);
        }

        public PagedViewModel<FornecedorViewModel> ObterFornecedorTodos(string nome, int pageSize, int pageNumber)
        {
            return _mapper.Map<PagedViewModel<FornecedorViewModel>>(
                _fornecedorService.ObterTodos(nome, pageSize, pageNumber));
        }


        public void RemoverEmpresa(Guid id)
        {
            BeginTransaction();
            _empresaService.Remover(id);
            Commit();
        }

        public void RemoverFornecedor(Guid id)
        {
            BeginTransaction();
            var fornecedores = _fornecedorService.ObterPorId(id);
            if(fornecedores != null)
            {
                foreach(var telefone in fornecedores.Telefones)
                {
                    _fornecedorService.RemoverTelefone(telefone.TelefoneId);
                }
                
            }
            
            _fornecedorService.Remover(id);
            Commit();
        }

        public void Dispose()
        {
            _empresaService.Dispose();
            _fornecedorService.Dispose();
            _estadoService.Dispose();
            GC.SuppressFinalize(this);
        }

        public TelefoneViewModel AdicionarTelefone(TelefoneViewModel telefoneViewModel)
        {
            var telefone = _mapper.Map<Telefone>(telefoneViewModel);

            BeginTransaction();
            _fornecedorService.AdicionarTelefone(telefone);
            Commit();

            return telefoneViewModel;
        }

        public TelefoneViewModel AtualizarTelefone(TelefoneViewModel telefoneViewModel)
        {
            var telefone = _mapper.Map<Telefone>(telefoneViewModel);

            BeginTransaction();
            _fornecedorService.AtualizarTelefone(telefone);
            Commit();

            return telefoneViewModel;
        }

        public TelefoneViewModel ObterTelefonePorId(Guid id)
        {
            return _mapper.Map<TelefoneViewModel>(_fornecedorService.ObterTelefonePorId(id));
        }

        public void RemoverEndereco(Guid id)
        {
            BeginTransaction();
            _fornecedorService.RemoverTelefone(id);
            Commit();
        }
    }
}