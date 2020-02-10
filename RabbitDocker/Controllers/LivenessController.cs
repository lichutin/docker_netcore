using Microsoft.AspNetCore.Mvc;

namespace RabbitDocker.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class LivenessController : ControllerBase
    {
        private static bool _osOk = true;

        [HttpGet]
        public IActionResult Check()
        {
            return _osOk
                ? new StatusCodeResult(200)
                : new StatusCodeResult(500);
        }

        [HttpGet]
        public IActionResult Set(bool isOk)
        {
            _osOk = isOk;
            return new StatusCodeResult(200);
        }
    }
}
