using MassTransit;
using Order.Domain.Enums;
using Order.Domain.Interfaces.Repositories;
using TradeSphere.Shared.Events.PaymentEvents;

namespace Order.Application.Consumers
{
    public class PaymentFailedEventConsumer : IConsumer<PaymentFailedEvent>
    {
        private readonly IOrderRepository _orderRepository;
        public PaymentFailedEventConsumer(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Consume(ConsumeContext<PaymentFailedEvent> context)
        {
            Order.Domain.Entities.Order order = await _orderRepository.GetSingleAsync(x => x.Id == context.Message.OrderId);
            order.Status = OrderStatus.Failed;
            await _orderRepository.UpdateAsync(order);
        }
    }
}
