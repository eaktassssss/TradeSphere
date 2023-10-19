using MassTransit;
using Order.Domain.Enums;
using Order.Domain.Interfaces.Repositories;
using Order.Persistence.DbContexts.EntityFramework;
using TradeSphere.Shared.Events.StockEvents;

namespace OrderService.Consumers
{
    public class StockNotReservedEventConsumer : IConsumer<StockNotReservedEvent>
    {

        private readonly IOrderRepository _orderRepository;
        public StockNotReservedEventConsumer(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Consume(ConsumeContext<StockNotReservedEvent> context)
        {
         
            Order.Domain.Entities.Order order = await _orderRepository.GetSingleAsync(x => x.Id == context.Message.OrderId);
            order.Status = OrderStatus.Failed;
            await _orderRepository.UpdateAsync(order);
        }
    }
}
