using Order.Domain.Interfaces.Repositories;
using Order.Persistence.DbContexts.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Implementations.Repositories
{
    public class OrderRepository : EfRepository<Order.Domain.Entities.Order>, IOrderRepository
    {
        public OrderRepository(OrderDbContext orderDbContext) : base(orderDbContext)
        {
        }
    }
}
