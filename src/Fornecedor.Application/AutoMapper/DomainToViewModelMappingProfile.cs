using AutoMapper;
using Fornecedor.Application.ViewModels;
using Fornecedor.Domain.DTO;
using Fornecedor.Domain.Entities;

namespace Fornecedor.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Telefone, FornecedorTelefoneViewModel>();
            CreateMap<Fornecedor, FornecedorTelefoneViewModel>();

            CreateMap<TipoPessoa, TipoPessoaViewModel>();
            CreateMap<Fornecedor, FornecedorViewModel>();
            CreateMap<Empresa, EmpresaViewModel>();
            CreateMap<Estado, EstadoViewModel>();
            CreateMap<Telefone, TelefoneViewModel>();
            CreateMap<Paged<Fornecedor>, PagedViewModel<FornecedorViewModel>>();
            CreateMap<Paged<Empresa>, PagedViewModel<EmpresaViewModel>>();
        }
    }
}