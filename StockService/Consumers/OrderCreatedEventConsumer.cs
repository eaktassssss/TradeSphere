using Amazon.Runtime.Internal.Util;
using MassTransit;
using MassTransit.Transports;
using StockService.Application.Interfaces.Repositories;
using StockService.Application.Interfaces.Services;
using StockService.Domain.Entities;
using TradeSphere.Shared.Endpoints;
using TradeSphere.Shared.Events.OrderEvents;
using TradeSphere.Shared.Events.StockEvents;
using TradeSphere.Shared.Messages;

namespace StockService.Consumers
{
    public class OrderCreatedEventConsumer : IConsumer<OrderCreatedEvent>
    {
        private readonly IStockRepository _stockRepository;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly ISendEndpointProvider _sendEndpointProvider;
        public OrderCreatedEventConsumer(IStockRepository stockRepository, IPublishEndpoint publishEndpoint, ISendEndpointProvider sendEndpointProvider)
        {
            _stockRepository = stockRepository;
            _publishEndpoint = publishEndpoint;
            _sendEndpointProvider = sendEndpointProvider;

        }
        public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {
            List<bool> stockCheck = new();
            foreach (OrderItemMessage orderItem in context.Message.OrderItems)
            {
                stockCheck.Add((await _stockRepository.GetAll(s => s.ProductId == orderItem.ProductId && s.Count >= orderItem.Count)).Any());
            }
            if (stockCheck.TrueForAll(x => x.Equals(true)))
            {
                foreach (OrderItemMessage orderItem in context.Message.OrderItems)
                {
                    Stock stock = await _stockRepository.GetAsync(x => x.ProductId == orderItem.ProductId);
                    stock.Count -= orderItem.Count;
                    await _stockRepository.UpdateAsync(stock.Id, stock);
                }

                StockReservedEvent stockReservedEvent = new StockReservedEvent();
                stockReservedEvent.OrderId = context.Message.OrderId;
                stockReservedEvent.CustomerId = context.Message.CustomerId;
                stockReservedEvent.TotalPrice = context.Message.TotalPrice;

                var sendEnpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri($"queue:{RabbitMQEndpointSettings.Payment_StockReservedEventQueue}"));
               await sendEnpoint.Send(stockReservedEvent);
            }

            else
            {
                StockNotReservedEvent stockNotReservedEvent = new StockNotReservedEvent();
                stockNotReservedEvent.CustomerId = context.Message.CustomerId;
                stockNotReservedEvent.OrderId = context.Message.CustomerId;
                stockNotReservedEvent.Message = "Insufficient stock";
            }
        }
    }
}
