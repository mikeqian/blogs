using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class ConfigController : ApiController
    {
        [HttpGet]
        [Route("api/mm")]
        public object GetConfigByAppNo()
        {
            return "111";
        }
    }
}
