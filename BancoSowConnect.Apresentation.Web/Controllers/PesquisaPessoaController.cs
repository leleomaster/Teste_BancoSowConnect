using BancoSowConnect.Domain.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BancoSowConnect.Apresentation.Web.Controllers
{
    public class PesquisaPessoaController : Controller
    {
        [HttpGet]
        public ActionResult Pesquisar()
        {
            return View(new PesquisaPessoaViewModel());
        }

        [HttpPost]
        public ActionResult Pesquisar(PesquisaPessoaViewModel model)
        {
            Teste_GetListaPessoa(model);

            return View(model);
        }


        private void Teste_GetListaPessoa(PesquisaPessoaViewModel model)
        {
            model.ListaPessoa = new List<PessoaViewModel>
                {
                    new PessoaViewModel
                    {
                        Conta = new ContaViewModel
                        {
                            Banco = new BancoViewModel
                            {
                                Id = 1,
                                IdUsuario = 14,
                                Nome = "Banco 1"
                            },
                            Ativa = true,
                            Id = 10,
                            DataCriada = DateTime.Now,
                            Numero = 4422665599884421,
                            Saldo = 16.000m
                        },
                        Documentos = new List<DocumentoViewModel>
                        {
                            new DocumentoViewModel
                            {
                                Numero = 34164899920,
                                Id = 1,
                                 TipoDocumentoEntity = new TipoDocumentoViewModel
                                 {
                                     Id = 1,
                                     Nome = "CPF"
                                 }
                            },
                            new DocumentoViewModel
                            {
                                Numero = 344449569,
                                Id = 2,
                                 TipoDocumentoEntity = new TipoDocumentoViewModel
                                 {
                                     Id = 2,
                                     Nome = "RG"
                                 }
                            },

                            new DocumentoViewModel
                            {
                                Numero = 99333666444499,
                                Id = 3,
                                 TipoDocumentoEntity = new TipoDocumentoViewModel
                                 {
                                     Id = 3,
                                     Nome = "CNPJ"
                                 }
                            },
                        },
                        Id = 1,
                        Nome = "Bill Gates",
                        TipoPessoa = "Juridíca"
                    },
            };
        }
    }
}