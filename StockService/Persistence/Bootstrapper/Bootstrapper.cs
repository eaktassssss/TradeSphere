using MassTransit.Configuration;
using Microsoft.Extensions.Options;
using Shared.Resources;
using StockService.Application.Interfaces.Repositories;
using StockService.Application.Interfaces.Services;
using StockService.Persistence.Implementations.Repositories;

using TradeSphere.Shared.Configurations.Mongo;

namespace StockService.Persistence.Bootstrapper
{
    public static class Bootstrapper
    {

        public static void AddPersistenceServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            #region Services
            services.Configure<MongoConfiguration>(configuration.GetSection(nameof(MongoConfiguration)));
            services.AddSingleton<IMongoConfiguration>(x => x.GetRequiredService<IOptions<MongoConfiguration>>().Value);
          
            services.AddScoped<IStockService, Implementations.Services.StockService>();
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<IResourceService,ResourceService>();
      

            #endregion
        }
    }
}
