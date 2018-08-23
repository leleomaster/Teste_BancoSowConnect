using BancoSowConnect.Domain.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BancoSowConnect.Apresentation.Web.Controllers
{
    public class TransacaoController : Controller
    {
        [HttpGet]
        public ActionResult Operacao(int idPessoa)
        {
            return View(new OperacaoViewModel() { NomePessoa = "Leonardo", SaldoConta = "16.000"});
        }

        [HttpPost]
        public ActionResult Operacao(OperacaoViewModel model)
        {
            return View(model);
        }
        
        [HttpGet]
        public ActionResult Tranferir(int idPessoa)
        {
            return View(new TransferenciaViewModel());
        }

        [HttpPost]
        public ActionResult Tranferir(TransferenciaViewModel model)
        {
            return View(model);
        }

        
    }
}