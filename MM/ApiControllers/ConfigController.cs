using System.Web.Http;

namespace Mike.MM.ApiControllers
{
    public class ConfigController : ApiController
    {
        [HttpGet]
        [Route("api/mm")]
        public object GetConfigByAppNo()
        {
            return "Hello MM!";
        }
    }
}
