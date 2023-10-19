using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeSphere.Shared.Events.StockEvents
{
    public class StockReservedEvent
    {
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
