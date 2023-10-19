using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeSphere.Shared.Events.PaymentEvents
{
    public class PaymentFailedEvent
    {
        public int OrderId { get; set; }
        public string Message { get; set; }
    }
}
