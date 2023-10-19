using Microsoft.Extensions.Options;
 
using PaymentService.Application.Interfaces.Repositories;
using PaymentService.Persistence.Implementations.Repositories;
using TradeSphere.Shared.Configurations.Mongo;

namespace PaymentService.Persistence.Bootstrapper
{
    public static class Bootstrapper
    {
        public static void AddPersistenceServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            #region Services
            services.AddSingleton<IMongoConfiguration>(x => x.GetRequiredService<IOptions<MongoConfiguration>>().Value);
            services.Configure<MongoConfiguration>(configuration.GetSection(nameof(MongoConfiguration)));
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IMongoConfiguration, MongoConfiguration>();
      
            #endregion
        }
    }
}
