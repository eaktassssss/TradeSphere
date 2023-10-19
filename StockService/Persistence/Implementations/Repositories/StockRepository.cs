 
using StockService.Application.Interfaces.Repositories;
using StockService.Domain.Entities;
using TradeSphere.Shared.Configurations.Mongo;

namespace StockService.Persistence.Implementations.Repositories
{
    public class StockRepository : MongoRepository<Stock>, IStockRepository
    {
        public StockRepository(IMongoConfiguration mongoConfiguration) : base(mongoConfiguration)
        {
        }
    }
}
