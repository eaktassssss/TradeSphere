using MassTransit;
using Order.Domain.Enums;
using Order.Domain.Interfaces.Repositories;
using TradeSphere.Shared.Events.PaymentEvents;
using TradeSphere.Shared.Events.StockEvents;

namespace OrderService.Consumers
{
    public class PaymentCompletedEventConsumer : IConsumer<PaymentCompletedEvent>
    {
        private readonly IOrderRepository _orderRepository;
        public PaymentCompletedEventConsumer(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Consume(ConsumeContext<PaymentCompletedEvent> context)
        {
            Order.Domain.Entities.Order order = await _orderRepository.GetSingleAsync(x => x.Id == context.Message.OrderId);
            order.Status = OrderStatus.Completed;
            await _orderRepository.UpdateAsync(order);
        }
    }
}
