using PaymentService.Domain.Entities;

namespace PaymentService.Application.Interfaces.Repositories
{
    public interface IPaymentRepository:IMongoRepository<Payment, string>
    {
    }
}
