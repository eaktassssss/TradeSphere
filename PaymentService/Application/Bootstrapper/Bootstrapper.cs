using MassTransit;
using PaymentService.Application.Interfaces.Repositories;
using PaymentService.Consumers;
using TradeSphere.Shared.Endpoints;

namespace PaymentService.Application.Bootstrapper
{
    public static class Bootstrapper
    {
        public static async void AddApplicationServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            #region MassTransit
            services.AddMassTransit(massTransit =>
            {
                massTransit.AddConsumer<StockReservedEventConsumer>();
                massTransit.UsingRabbitMq((context, configurator) =>
                {
                    configurator.Host(configuration.GetSection("RabbitMQ").Value);
                    configurator.ReceiveEndpoint(RabbitMQEndpointSettings.Payment_StockReservedEventQueue, e => e.ConfigureConsumer<StockReservedEventConsumer>(context));
                });
            });
            services.AddMassTransitHostedService();
            #endregion
        }
    }

    
}
