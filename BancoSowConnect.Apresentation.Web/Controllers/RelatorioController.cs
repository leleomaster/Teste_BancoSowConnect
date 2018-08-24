using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BancoSowConnect.Apresentation.Web.Controllers
{
    [RoutePrefix("relatorio")]
    public class RelatorioController : Controller
    {
        [Route("index/{idPessoa}")]
        // GET: Relatorio
        public ActionResult Index(int idPessoa)
        {
            return View();
        }

        [Route("index/{idPessoa}")]
        [HttpPost]
        // GET: Relatorio
        public ActionResult Index()
        {
            return View();
        }
    }
}