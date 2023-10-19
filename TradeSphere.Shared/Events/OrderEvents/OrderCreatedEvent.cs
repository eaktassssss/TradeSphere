using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeSphere.Shared.Events.Common;
using TradeSphere.Shared.Messages;

namespace TradeSphere.Shared.Events.OrderEvents
{
    public class OrderCreatedEvent:IEvent
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderItemMessage> OrderItems { get; set; }
    }
}
