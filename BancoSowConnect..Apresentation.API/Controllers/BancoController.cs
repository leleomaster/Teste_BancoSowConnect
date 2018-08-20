using BancoSowConnect.Aplication.Service.Interfaces;
using BancoSowConnect.Domain.Model.ReturnPattern;
using BancoSowConnect.Domain.Model.ViewModels;
using System.Collections.Generic;
using System.Web.Http;

namespace BancoSowConnect.Apresentation.API.Controllers
{
    [RoutePrefix("api/banco")]
    public class BancoController : BaseController
    {
        private readonly IBancoService _bancoService;

        public BancoController(IBancoService bancoService) => _bancoService = bancoService;

        [Route("v1/obter")]
        public BaseRetornoDTO<List<BancoViewModel>> Get() => _bancoService.SelectAll();

        [Route("v1/obter")]
        // GET api/<controller>/5
        public BaseRetornoDTO<BancoViewModel> Get(int id) => _bancoService.GetById(id);

        [Route("v1/criar")]
        // POST api/<controller>
        public BaseRetornoDTO<int> Post([FromBody]BancoViewModel bancoViewModel)
        {
            bancoViewModel.IdUsuario = CodigoUsuario;
            return _bancoService.Insert(bancoViewModel);
        }

        [Route("v1/atualizar")]
        // PUT api/<controller>/5
        public BaseRetornoDTO<bool> Put([FromBody]BancoViewModel bancoViewModel) => _bancoService.Update(bancoViewModel);

        [Route("v1/excluir")]
        // DELETE api/<controller>/5
        public BaseRetornoDTO<bool> Delete(int id) => _bancoService.Delete(id);
    }
}