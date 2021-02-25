using Market.Api.Models;
using Market.Api.Services;
using Market.Api.Validations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        public IActionResult Create(ICollection<OrderItem> items)
        {
            var order = new Order
            {
                CreatedAt = DateTime.Now,
                Items = items
            };

            var orderValidator = new OrderValidator().Validate(order);
            
            if (!orderValidator.IsValid) return BadRequest(orderValidator.Errors.ToString());

            return Accepted(order);
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