using MediatR;
using Order.Application.Dtos;
using Order.Application.Features.Commands;
using Order.Application.Features.Commands.Response;
using Order.Domain.Entities;
using Order.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeSphere.Shared.Events.OrderEvents;
using TradeSphere.Shared.Messages;

namespace Order.Application.Features.Commands.Request
{
    public class CreateOrderCommandRequest : IRequest<CreateOrderCommandResponse>
    {
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
        #region MapToResponse
        public CreateOrderCommandResponse MapToResponse(Order.Domain.Entities.Order order)
        {
            return new CreateOrderCommandResponse { OrderDate = order.OrderDate, OrderId = order.Id };
        }
        #endregion
        #region MapToEvent
        public OrderCreatedEvent MapToOrderCreatedEvent(Domain.Entities.Order order)
        {
            OrderCreatedEvent orderCreatedEvent = new OrderCreatedEvent();
            orderCreatedEvent.OrderId = order.Id;
            orderCreatedEvent.CustomerId = order.CustomerId;
            foreach (OrderItems item in order.OrderItems)
            {
                orderCreatedEvent.OrderItems.Add(new OrderItemMessage()
                {
                    ProductId = item.ProductId,
                    Count = item.Quantity
                });
            }
            return orderCreatedEvent;
        }
        #endregion
    }
}
