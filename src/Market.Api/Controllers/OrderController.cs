using Microsoft.AspNetCore.Mvc;

namespace Market.Api.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrderController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Create()
        {
            return Accepted();
        }
    }
}