using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Order.Persistence.DbContexts.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Persistence.Bootstrapper
{
    public static class Bootstrapper
    {
        public static void AddPersistenceServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {

            #region Services
            services.AddDbContext<OrderDbContext>(x => x.UseSqlServer(configuration.GetConnectionString("OrderServiceConString")));
            #endregion
        }
    }
}
