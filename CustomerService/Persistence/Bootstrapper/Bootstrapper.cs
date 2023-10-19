using Microsoft.EntityFrameworkCore;
using Shared.Resources;
using CustomerService.Application.Interfaces.Repositories;
using CustomerService.Application.Interfaces.Services;
using CustomerService.Application.Interfaces.UnitOfWork;
using CustomerService.Persistence.Implementations.Repositories;
using CustomerService.Persistence.Context.EntityFramework;
using CustomerService.Persistence.Implementations.UnitOfWork;

namespace CustomerService.Persistence.Bootstrapper
{
    public static class Bootstrapper
    {
        public static void AddPersistenceServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            #region Services
            services.AddDbContext<CustomerDdContext>(x => x.UseSqlServer(configuration.GetConnectionString("CustomerServiceConString")));

            services.AddScoped<ICustomerService, Implementations.Services.CustomerService>();

            #endregion
            #region Repositories DI
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IResourceService, ResourceService>();
            #endregion
            #region UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion
        }
    }
}
