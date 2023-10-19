using Order.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Interfaces.Repositories
{
    public interface IOrderRepository:IEfRepository<Entities.Order>
    {
    }
}
