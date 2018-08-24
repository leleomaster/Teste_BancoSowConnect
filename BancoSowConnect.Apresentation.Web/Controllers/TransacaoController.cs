using BancoSowConnect.Domain.Entity.Enums;
using BancoSowConnect.Domain.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BancoSowConnect.Apresentation.Web.Controllers
{
    [RoutePrefix("transacao")]
    public class TransacaoController : Controller
    {
        [HttpGet]
        [Route("operacao/{idPessoa:int}")]
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
        [Route("transferir/{idPessoa}")]
        public ActionResult Transferir(int idPessoa)
        {
            return View(TesteTransferenciaViewModel());
        }

        [HttpPost]
        public ActionResult Transferir(TransferenciaViewModel model)
        {
            return View(model);
        }


        private TransferenciaViewModel TesteTransferenciaViewModel()
        {
            return new TransferenciaViewModel
            {
                ContaCredito = new ContaViewModel
                {
                    Saldo = 1000,
                    Numero = 9999444477778888,
                    TipoConta = TipoContaEnum.CORRENTE,
                    Pessoa = new PessoaViewModel
                    {
                        Nome = "Leonardo"
                    },
                    Banco = new BancoViewModel
                    {
                        Nome = "Banco I"
                    }
                },
                ContaDebito = new ContaViewModel
                {
                    Saldo = 1500,
                    Numero = 1111888844446666,
                    TipoConta = TipoContaEnum.POUPANCA,
                    Pessoa = new PessoaViewModel
                    {
                        Nome = "Renato"
                    },
                    Banco = new BancoViewModel
                    {
                        Nome = "Banco VVV"
                    }
                }
            };
        }

    }
}