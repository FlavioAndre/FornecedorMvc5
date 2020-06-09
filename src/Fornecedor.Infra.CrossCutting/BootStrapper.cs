using Fornecedor.Application.Interfaces;
using Fornecedor.Application.Services;
using Fornecedor.Domain.Interfaces;
using Fornecedor.Domain.Interfaces.Repository;
using Fornecedor.Domain.Interfaces.Service;
using Fornecedor.Domain.Services;
using Fornecedor.Infra.Data.Context;
using Fornecedor.Infra.Data.Interfaces;
using Fornecedor.Infra.Data.Repository;
using Fornecedor.Infra.Data.UoW;
using SimpleInjector;

namespace Fornecedor.Infra.CrossCutting
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            // App
            container.Register<IFornecedorEmpresaAppService, FornecedorEmpresaAppService>(Lifestyle.Scoped);

            // Domain
            container.Register<IFornecedorService, FornecedorService>(Lifestyle.Scoped);
            container.Register<IEmpresaService, EmpresaService>(Lifestyle.Scoped);
            container.Register<IEstadoService, EstadoService>(Lifestyle.Scoped);


            // Infra Dados
            container.Register<IFornecedorRepository, FornecedorRepository>(Lifestyle.Scoped);
            container.Register<IEmpresaRepository, EmpresaRepository>(Lifestyle.Scoped);
            container.Register<IEstadoRepository, EstadoRepository>(Lifestyle.Scoped);
            container.Register<ITelefoneRepository, TelefoneRepository>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<FornecedorContext>(Lifestyle.Scoped);
        }
    }
}