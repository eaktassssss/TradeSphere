using MassTransit.Mediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockService.Application.Contract.Request;
using StockService.Application.Interfaces.Services;

namespace StockService.Controllers
{
    [Route("api/")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        IStockService _stockService;

        public StocksController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpPost]
        [Route("stock")]
        public async Task<IActionResult> CreateAsync(CreateStockRequest createStockRequest)
        {
            var response = await _stockService.CreateAsync(createStockRequest);
            return Ok(response);
        }
    }
}
