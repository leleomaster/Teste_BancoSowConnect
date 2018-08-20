using BancoSowConnect.Aplication.Service.Interfaces;
using BancoSowConnect.Domain.Model.ReturnPattern;
using BancoSowConnect.Domain.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BancoSowConnect.Apresentation.API.Controllers
{
    [RoutePrefix("api/pessoa")]
    public class PessoaController : BaseController
    {
        private readonly IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService) => _pessoaService = pessoaService;

        [Route("v1/obter")]
        // GET api/<controller>/5
        public BaseRetornoDTO<PessoaViewModel> Get(int id) => _pessoaService.GetById(id);

        [Route("v1/criar")]
        // POST api/<controller>
        public BaseRetornoDTO<int> Post([FromBody]PessoaViewModel bancoViewModel)
        {
            return _pessoaService.Insert(bancoViewModel);
        }

        [Route("v1/atualizar")]
        // PUT api/<controller>/5
        public BaseRetornoDTO<bool> Put([FromBody]PessoaViewModel bancoViewModel) => _pessoaService.Update(bancoViewModel);

        [Route("v1/excluir")]
        // DELETE api/<controller>/5
        public BaseRetornoDTO<bool> Delete(int id) => _pessoaService.Delete(id);
    }
}
