using BancoSowConnect.Apresentation.Web.ComunicationAPI;
using BancoSowConnect.Domain.Model.ReturnPattern;
using BancoSowConnect.Domain.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BancoSowConnect.Apresentation.Web.Controllers
{
    [Authorize]
    public class BancoController : Controller
    {
        private readonly CallAPIHttpClient<BancoViewModel> _callAPIHttpClient;
        private readonly string methodAPICreate = "banco/v1/criar";
        private readonly string methodAPIDelete = "banco/v1/excluir/";
        private readonly string methodAPIEdit = "banco/v1/atualizar/";
        private readonly string methodAPISearch = "banco/v1/obter/";

        public BancoController()
        {
            _callAPIHttpClient = new CallAPIHttpClient<BancoViewModel>();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BancoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var retorno = await _callAPIHttpClient.PostAsync(model, methodAPICreate);
                ViewBag.BaseRetornoDTO = retorno;
            }
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var retorno = await _callAPIHttpClient.GetAsync(id, methodAPISearch);
            if (retorno.EStatusResponse != EStatusResponse.Success)
            {
                ViewBag.BaseRetornoDTO = retorno;
            }
            return View(retorno.Value);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(BancoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var retorno = await _callAPIHttpClient.PutAsync(model, methodAPIEdit);
                ViewBag.BaseRetornoDTO = retorno;
            }
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var retorno = await _callAPIHttpClient.GetAsync(id, methodAPISearch);
            return View(retorno.Value);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<ActionResult> DeleteBanco(int id)
        {
            var retorno = await _callAPIHttpClient.DeleteAsync(id, methodAPIDelete);

            if (retorno.EStatusResponse == EStatusResponse.Success)
            {
                return RedirectToAction("Search");
            }

            ViewBag.BaseRetornoDTO = retorno;

            return View(new BancoViewModel());            
        }

        [HttpGet]
        public async Task<ActionResult> Search()
        {
            CallAPIHttpClient<List<BancoViewModel>> callAPIHttpClient = new CallAPIHttpClient<List<BancoViewModel>>();

            var retorno = await callAPIHttpClient.GetAsync(null, methodAPISearch);
            return View(retorno);
        }
    }
}