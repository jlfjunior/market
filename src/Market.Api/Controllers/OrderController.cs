using Market.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text;

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

        [HttpPost("download/csv")]
        public IActionResult GetCsv()
        {
            var fileName = "arquivo.csv";
            var fileService = new FileService();
            Response.Headers.Add("Content-Disposition", $"attachment; filename={fileName}");

            return File(Encoding.UTF8.GetBytes(fileService.Content()), "text/csv");
        }
    }
}