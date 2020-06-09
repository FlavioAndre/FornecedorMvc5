using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Fornecedor.Application.Interfaces;
using Fornecedor.Application.ViewModels;

namespace Fornecedor.UI.Web.Controllers
{
    [RoutePrefix("empresas")]
    [Route("{action=listar}")]
    public class EmpresaController : BaseController
    {
        private readonly IFornecedorEmpresaAppService _fornecedorEmpresaAppService;

        public EmpresaController(IFornecedorEmpresaAppService fornecedorEmpresaAppService)
        {
            _fornecedorEmpresaAppService = fornecedorEmpresaAppService;
        }

        // GET: Empresa
        [Route("listar")]
        public ActionResult Index(string buscar, int pageNumber = 1)
        {
            var paged = _fornecedorEmpresaAppService.ObterEmpresaTodos(buscar, PageSize, pageNumber);
            ViewBag.TotalCount = Math.Ceiling((double) paged.Count / PageSize);
            ViewBag.PageNumber = pageNumber;
            ViewBag.SearchData = buscar;
            return View(paged.List);
        }

        [Route("detalhes/{id:guid}")]
        public ActionResult Details(Guid? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var empresaViewModel = _fornecedorEmpresaAppService.ObterEmpresaPorId(id.Value);
            if (empresaViewModel == null) return HttpNotFound();
            return View(empresaViewModel);
        }

        private SelectList MontaSelectListEstados(string uf)
        {
            var lista = _fornecedorEmpresaAppService.ObeterEstadoTodos();

            return new SelectList(
                lista,
                "Uf",
                "Nome",
                uf
            );
        }

        [Route("incluir-novo")]
        public ActionResult Create()
        {
            ViewBag.Uf = MontaSelectListEstados(null);
            return View();
        }


        [Route("incluir-novo")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmpresaViewModel empresaViewModel)
        {
            ViewBag.UF = MontaSelectListEstados(empresaViewModel.Uf);
            if (ModelState.IsValid)
            {
                empresaViewModel = _fornecedorEmpresaAppService.AdicionarEmpresa(empresaViewModel);
                if (!empresaViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in empresaViewModel.ValidationResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, erro.ErrorMessage);
                    }
                    return View(empresaViewModel);
                }
                return RedirectToAction("Index");
            }
            
            return View(empresaViewModel);
        }


        [Route("editar/{id:guid}")]
        public ActionResult Edit(Guid? id)
        {
            ViewBag.Acao = "Editar Empresa";

            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var empresaViewModel = _fornecedorEmpresaAppService.ObterEmpresaPorId(id.Value);
            if (empresaViewModel == null) return HttpNotFound();

            ViewBag.Uf = MontaSelectListEstados(empresaViewModel.Uf);
            ViewBag.EmpresaId = id;
            return View(empresaViewModel);
        }

        [Route("editar/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmpresaViewModel empresaViewModel)
        {
            ViewBag.Uf = MontaSelectListEstados(empresaViewModel.Uf);
            if (ModelState.IsValid)
            {
                empresaViewModel = _fornecedorEmpresaAppService.AtualizarEmpresa(empresaViewModel);

                if (!empresaViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in empresaViewModel.ValidationResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, erro.ErrorMessage);
                    }
                    return View(empresaViewModel);
                }
                return RedirectToAction("Index");
            }
            return View(empresaViewModel);
        }

        [Route("excluir/{id:guid}")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var empresaViewModel = _fornecedorEmpresaAppService.ObterEmpresaPorId(id.Value);
            if (empresaViewModel == null) return HttpNotFound();
            return View(empresaViewModel);
        }

        [Route("excluir/{id:guid}")]
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _fornecedorEmpresaAppService.RemoverEmpresa(id);
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing) _fornecedorEmpresaAppService.Dispose();
            base.Dispose(disposing);
        }
    }
}