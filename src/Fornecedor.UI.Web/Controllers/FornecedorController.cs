using System;
using System.Net;
using System.Web.Mvc;
using Fornecedor.Application.Interfaces;
using Fornecedor.Application.ViewModels;

namespace Fornecedor.UI.Web.Controllers
{
    [RoutePrefix("fornecedores")]
    [Route("{action=listar}")]
    public class FornecedorController : BaseController
    {
        private readonly IFornecedorEmpresaAppService _fornecedorEmpresaAppService;

        public FornecedorController(IFornecedorEmpresaAppService fornecedorEmpresaAppService)
        {
            _fornecedorEmpresaAppService = fornecedorEmpresaAppService;
        }

        private SelectList MontaSelectListEmpresas(Guid id)
        {
            var lista = _fornecedorEmpresaAppService.ObterEmpresaTodos();

            return new SelectList(
                lista,
                "EmpresaId",
                "NomeFantasia",
                id
            );
        }

        // GET: Fornecedor
        [Route("listar")]
        public ActionResult Index(string buscar, int pageNumber = 1)
        {
            var paged = _fornecedorEmpresaAppService.ObterFornecedorTodos(buscar, PageSize, pageNumber);
            ViewBag.TotalCount = Math.Ceiling((double) paged.Count / PageSize);
            ViewBag.PageNumber = pageNumber;
            ViewBag.SearchData = buscar;
            return View(paged.List);
        }

        [Route("detalhes/{id:guid}")]
        public ActionResult Details(Guid? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var fornecedorViewModel = _fornecedorEmpresaAppService.ObterFornecedorPorId(id.Value);
            if (fornecedorViewModel == null) return HttpNotFound();
            return View(fornecedorViewModel);
        }

        [Route("incluir-novo")]
        public ActionResult Create()
        {
            ViewBag.EmpresaId = MontaSelectListEmpresas(Guid.Empty);
            return View();
        }


        [Route("incluir-novo")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FornecedorTelefoneViewModel fornecedorViewModel)
        {
            ViewBag.EmpresaId = MontaSelectListEmpresas(fornecedorViewModel.EmpresaId);
            if (ModelState.IsValid)
            {
                fornecedorViewModel = _fornecedorEmpresaAppService.AdicionarFornecedor(fornecedorViewModel);
                if (!fornecedorViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in fornecedorViewModel.ValidationResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, erro.ErrorMessage);
                    }
                    return View(fornecedorViewModel);
                }
                return RedirectToAction("Index");
            }
            return View(fornecedorViewModel);
        }


        [Route("editar/{id:guid}")]
        public ActionResult Edit(Guid? id)
        {
            ViewBag.Acao = "Editar Fornecedor";

            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var fornecedorViewModel = _fornecedorEmpresaAppService.ObterFornecedorPorId(id.Value);
            if (fornecedorViewModel == null) return HttpNotFound();

            fornecedorViewModel.Numero = fornecedorViewModel.Telefones[0].Numero;
            ViewBag.PessoaFisicaSelecionda = fornecedorViewModel.TipoFornecedor == TipoPessoaViewModel.FISICA;
            ViewBag.FornecedorID = id;
            ViewBag.EmpresaId = MontaSelectListEmpresas(fornecedorViewModel.EmpresaId);
            return View(fornecedorViewModel);
        }

        [Route("editar/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FornecedorTelefoneViewModel fornecedorViewModel)
        {
            ViewBag.EmpresaId = MontaSelectListEmpresas(fornecedorViewModel.EmpresaId);
            if (ModelState.IsValid)
            {
                fornecedorViewModel = _fornecedorEmpresaAppService.AtualizarFornecedor(fornecedorViewModel);

                if (!fornecedorViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in fornecedorViewModel.ValidationResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, erro.ErrorMessage);
                    }
                    return View(fornecedorViewModel);
                }
                return RedirectToAction("Index");
            }
            return View(fornecedorViewModel);
        }

        [Route("excluir/{id:guid}")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var fornecedorViewModel = _fornecedorEmpresaAppService.ObterFornecedorPorId(id.Value);
            if (fornecedorViewModel == null) return HttpNotFound();
            return View(fornecedorViewModel);
        }

        [Route("excluir/{id:guid}")]
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _fornecedorEmpresaAppService.RemoverFornecedor(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) _fornecedorEmpresaAppService.Dispose();
            base.Dispose(disposing);
        }
    }
}