using PaymentService.Domain.Common;
using PaymentService.Domain.Enums;

namespace PaymentService.Domain.Entities
{
    public class Payment:BaseEntity
    {
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }
}
