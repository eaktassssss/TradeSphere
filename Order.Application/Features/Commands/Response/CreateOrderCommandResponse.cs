using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Features.Commands.Response
{
    public class CreateOrderCommandResponse
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
