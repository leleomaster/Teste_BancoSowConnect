using BancoSowConnect.Domain.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BancoSowConnect.Apresentation.Web.Controllers
{
    [RoutePrefix("Transacao")]
    public class TransacaoController : Controller
    {
        [HttpGet]
        [Route("Operacao/{int:idPessoa}")]
        public ActionResult Operacao(int? idPessoa)
        {
            return View(new OperacaoViewModel() { NomePessoa = "Leonardo", SaldoConta = "16.000"});
        }

        [HttpPost]
        public ActionResult Operacao(OperacaoViewModel model)
        {
            return View(model);
        }
        
        [HttpGet]
        public ActionResult Transferencia(int idPessoa)
        {
            return View(new TransferenciaViewModel());
        }

        [HttpPost]
        public ActionResult Transferencia(TransferenciaViewModel model)
        {
            return View(model);
        }

        
    }
}