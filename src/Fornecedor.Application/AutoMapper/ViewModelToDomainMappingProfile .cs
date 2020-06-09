using AutoMapper;
using Fornecedor.Application.ViewModels;
using Fornecedor.Domain.Entities;

namespace Fornecedor.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<FornecedorTelefoneViewModel, Fornecedor>();
            CreateMap<FornecedorTelefoneViewModel, Telefone>();
            CreateMap<FornecedorViewModel, Fornecedor>();
            CreateMap<EmpresaViewModel, Empresa>();
            CreateMap<EstadoViewModel, Estado>();
            CreateMap<TelefoneViewModel, Telefone>();
            CreateMap<TipoPessoaViewModel, TipoPessoa>();
        }
    }
}