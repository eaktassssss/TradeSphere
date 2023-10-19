using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Order.Application.Consumers;
using Order.Application.Implementations.Repositories;
using Order.Application.Implementations.UnitOfWork;
using Order.Domain.Interfaces.Repositories;
using Order.Domain.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeSphere.Shared.Endpoints;

namespace Order.Application.Bootstrapper
{
    public static class Bootstrapper
    {
        public static async void AddApplicationServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            #region Repositories
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion


            #region MassTransit
            services.AddMassTransit(massTransit =>
            {
                massTransit.AddConsumer<PaymentCompletedEventConsumer>();
                massTransit.AddConsumer<StockNotReservedEventConsumer>();
                massTransit.AddConsumer<PaymentFailedEventConsumer>();
                massTransit.UsingRabbitMq((context, configurator) =>
                {
                    configurator.Host(configuration.GetSection("RabbitMQ").Value);

                    configurator.ReceiveEndpoint(RabbitMQEndpointSettings.Order_PaymentCompletedEventQueue, e => e.ConfigureConsumer<PaymentCompletedEventConsumer>(context));
                    configurator.ReceiveEndpoint(RabbitMQEndpointSettings.Order_StockNotReservedEventQueue, e => e.ConfigureConsumer<StockNotReservedEventConsumer>(context));
                    configurator.ReceiveEndpoint(RabbitMQEndpointSettings.Order_PaymentFailedEventQueue, e => e.ConfigureConsumer<PaymentFailedEventConsumer>(context));
                });
            });

            services.AddMassTransitHostedService();
            #endregion
        }
    }
}
