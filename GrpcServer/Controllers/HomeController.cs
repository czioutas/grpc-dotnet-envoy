using Microsoft.AspNetCore.Mvc;

namespace GrpcServer
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    [ApiExplorerSettings(IgnoreApi = false, GroupName = "v1")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public ActionResult Index()
        {
            return Ok(1);
        }
    }
}