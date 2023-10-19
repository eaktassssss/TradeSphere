using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeSphere.Shared.Events.Common;

namespace TradeSphere.Shared.Events.StockEvents
{
    public class StockNotReservedEvent : IEvent
    {
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public string Message { get; set; }
    }
}
