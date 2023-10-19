
using MassTransit;
using MediatR;
using Order.Application.Features.Commands.Request;
using Order.Application.Features.Commands.Response;
 
using Order.Domain.Interfaces.Repositories;
using Order.Domain.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeSphere.Shared.Events.OrderEvents;

namespace Order.Application.Features.CommandHandlers
{
    public class CreateOrderCommandRequestHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPublishEndpoint _publishEndpoint;

        public CreateOrderCommandRequestHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork, IPublishEndpoint publishEndpoint)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _publishEndpoint = publishEndpoint;
        }
        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {

            Domain.Entities.Order order = new Domain.Entities.Order(request.CustomerId, DateTime.Now);
            foreach (var detail in request.OrderItems)
            {
                order.AddOrderItem(detail.ProductId, detail.Quantity, detail.UnitPrice);
            }
            order.CalculateTotalPrice();
            var orderCreatedResponse = await _orderRepository.AddAsync(order);
            await _unitOfWork.CommitAsync();

            #region Event Publish
            OrderCreatedEvent orderCreatedEvent = request.MapToOrderCreatedEvent(orderCreatedResponse);
            await _publishEndpoint.Publish(orderCreatedEvent);
            #endregion
            return request.MapToResponse(orderCreatedResponse);
        }
    }

}


