using MassTransit;
using MassTransit.Transports;
using PaymentService.Application.Contract.Request;
using PaymentService.Application.Interfaces.Operations;
using PaymentService.Domain.Entities;
using TradeSphere.Shared.Events.PaymentEvents;
using TradeSphere.Shared.Events.StockEvents;

namespace PaymentService.Consumers
{
    public class StockReservedEventConsumer : IConsumer<StockReservedEvent>
    {
        private readonly IPaymentService _paymentService;
        readonly IPublishEndpoint _publishEndpoint;
        public StockReservedEventConsumer(IPaymentService paymentService, IPublishEndpoint publishEndpoint)
        {
            _paymentService = paymentService;
            _publishEndpoint = publishEndpoint;
        }

        public async Task Consume(ConsumeContext<StockReservedEvent> context)
        {
            var createPaymentRequest = new CreatePaymentRequest();
            createPaymentRequest.PaymentStatus = Domain.Enums.PaymentStatus.Completed;
            createPaymentRequest.PaymentDate = DateTime.Now;
            createPaymentRequest.OrderId = context.Message.OrderId;
            createPaymentRequest.Amount = context.Message.TotalPrice;
            var payment = await _paymentService.CreateAsync(createPaymentRequest);
            if (payment.Success)
            {
                PaymentCompletedEvent paymentCompletedEvent = new PaymentCompletedEvent();
                paymentCompletedEvent.OrderId = context.Message.OrderId;
                await _publishEndpoint.Publish(paymentCompletedEvent);
            }
            else
            {
                PaymentFailedEvent paymentFailedEvent = new PaymentFailedEvent();
                paymentFailedEvent.Message = payment.Message;
                paymentFailedEvent.OrderId = context.Message.OrderId;
                await _publishEndpoint.Publish(paymentFailedEvent);
            }
        }
    }
}
