using StockService.Domain.Entities;

namespace StockService.Application.Interfaces.Repositories
{
    public interface IStockRepository:IMongoRepository<Stock,string>
    {
    }
}
