using CustomerService.Application.Interfaces.Repositories;
using CustomerService.Domain.Entities;
using CustomerService.Persistence.Context.EntityFramework;

namespace CustomerService.Persistence.Implementations.Repositories
{
    public class CustomerRepository : EfRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(CustomerDdContext customerDbContext) : base(customerDbContext)
        {
        }
    }
}
