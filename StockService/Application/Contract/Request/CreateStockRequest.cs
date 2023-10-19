using StockService.Application.Contract.Response;
using StockService.Domain.Entities;
using static MongoDB.Driver.WriteConcern;

namespace StockService.Application.Contract.Request
{
    public class CreateStockRequest
    {
        public int ProductId { get; set; }
        public int Count { get; set; }

        public Stock MapToEntity()
        {
            return new Stock
            {
                ProductId = this.ProductId,
                Count = this.Count

            };
        }

        public CreateStockResponse MapToPaylod(Stock stock)
        {
            return new CreateStockResponse()
            {
                ProductId = stock.ProductId,
                Count = stock.Count
            };
        }
    }
}
