using PaymentService.Domain.Enums;

namespace PaymentService.Application.Contract.Response
{
    public class CreatePaymentResponse
    {
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
  
    }
}
