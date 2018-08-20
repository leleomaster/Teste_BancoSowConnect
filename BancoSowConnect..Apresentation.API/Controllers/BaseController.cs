using System.Web.Http;
using System.Web.Http.Cors;

namespace BancoSowConnect.Apresentation.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BaseController : ApiController
    {
        public int CodigoUsuario
        {
            get
            {
                return 0;
            }
        }
    }
}
