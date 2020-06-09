using System.Collections.Generic;
using System.Web.Http;
using Fornecedor.Application.Interfaces;
using Fornecedor.Application.ViewModels;

namespace Fornecedor.Services.Api.Controllers
{
    public class EmpresaController : ApiController
    {
        private readonly IFornecedorEmpresaAppService _fornecedorEmpresaAppService;

        public EmpresaController(IFornecedorEmpresaAppService fornecedorEmpresaAppService)
        {
            _fornecedorEmpresaAppService = fornecedorEmpresaAppService;
        }

        // GET: api/Clientes
        [HttpGet]
        public IEnumerable<FornecedorViewModel> ListarTodos(string nome, int pageSize, int pageNumber)
        {
            return _fornecedorEmpresaAppService.ObterFornecedorTodos(nome, pageSize, pageNumber).List;
        }
    }
}