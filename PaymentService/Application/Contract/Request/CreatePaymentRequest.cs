using PaymentService.Application.Contract.Response;
using PaymentService.Domain.Entities;
using PaymentService.Domain.Enums;

namespace PaymentService.Application.Contract.Request
{
    public class CreatePaymentRequest
    {
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentStatus PaymentStatus { get; set; }

        public Payment MapToEntity()
        {
            return new Payment { OrderId = OrderId, Amount = Amount, PaymentDate = PaymentDate, PaymentStatus = PaymentStatus };
        }

        public CreatePaymentResponse MapToPaylod(Payment payment)
        {
            return new CreatePaymentResponse()
            {
                PaymentId = PaymentId,
                Amount = payment.Amount,
                PaymentDate = payment.PaymentDate,
            };
        }
    }
}
