using BancoSowConnect.Apresentation.Web.ComunicationAPI;
using BancoSowConnect.Apresentation.Web.ComunicationAPI.Interfaces;
using BancoSowConnect.Domain.Model.ReturnPattern;
using BancoSowConnect.Domain.Model.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PessoaSowConnect.Apresentation.Web.Controllers
{
    public class PessoaController : Controller
    {
        private readonly ICallAPIHttpClient<PessoaViewModel> _callAPIHttpClient;
        private readonly string methodAPICreate = "pessoa/v1/criar";
        private readonly string methodAPIDelete = "pessoa/v1/excluir/";
        private readonly string methodAPIEdit = "pessoa/v1/atualizar/";
        private readonly string methodAPISearch = "pessoa/v1/obter/";

        public PessoaController()
        {
            _callAPIHttpClient = new CallAPIHttpClient<PessoaViewModel>();
        }

        [HttpGet]
        public ActionResult Create()
        {
            PessoaViewModel model = new PessoaViewModel()
            {
                Documentos = new List<DocumentoViewModel>
                {
                    new DocumentoViewModel()
                    {
                        TipoDocumentoEntity = new TipoDocumentoViewModel()
                        {
                            Nome = "CPF",
                            Descricao = "Cadastro de Pessoa Fisíca"
                        }
                    },
                    new DocumentoViewModel()
                    {
                        TipoDocumentoEntity = new TipoDocumentoViewModel()
                        {
                            Nome = "CNPJ",
                            Descricao = "Cadastro Nacional da Pessoa Jurídica "
                        }
                    },
                    new DocumentoViewModel()
                    {
                        TipoDocumentoEntity = new TipoDocumentoViewModel()
                        {
                            Nome = "RG",
                            Descricao = "Registro Geral"
                        }
                    },
                }
            };


            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PessoaViewModel model)
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
        public async Task<ActionResult> Edit(PessoaViewModel model)
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
        public async Task<ActionResult> DeletePessoa(int id)
        {
            var retorno = await _callAPIHttpClient.DeleteAsync(id, methodAPIDelete);

            if (retorno.EStatusResponse == EStatusResponse.Success)
            {
                return RedirectToAction("Search");
            }

            ViewBag.BaseRetornoDTO = retorno;

            return View(new PessoaViewModel());
        }

        [HttpGet]
        public async Task<ActionResult> Search()
        {
            var retorno = await _callAPIHttpClient.GetListAsync(methodAPISearch);
            return View(retorno);
        }
    }
}