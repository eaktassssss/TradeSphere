using MassTransit;
using StockService.Application.Interfaces.Repositories;
using StockService.Consumers;
using StockService.Persistence.Implementations.Repositories;
using TradeSphere.Shared.Endpoints;
using TradeSphere.Shared.Events.OrderEvents;

namespace StockService.Application.Bootstrapper
{
    public static class Bootstrapper
    {
        public static async void AddApplicationServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            #region MassTransit
            services.AddMassTransit(massTransit =>
            {
                massTransit.AddConsumer<OrderCreatedEventConsumer>();
                massTransit.UsingRabbitMq((context, configurator) =>
                {
                    configurator.Host(configuration.GetSection("RabbitMQ").Value);
                    configurator.ReceiveEndpoint(RabbitMQEndpointSettings.Stock_OrderCreatedEventQueue, e => e.ConfigureConsumer<OrderCreatedEventConsumer>(context));
                });
            });
            services.AddMassTransitHostedService();
            #endregion
        }
    }
}
