
using PaymentService.Application.Interfaces.Repositories;
using PaymentService.Domain.Entities;
using TradeSphere.Shared.Configurations.Mongo;

namespace PaymentService.Persistence.Implementations.Repositories
{
    public class PaymentRepository : MongoRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(IMongoConfiguration mongoConfiguration) : base(mongoConfiguration)
        {
        }
    }
}
