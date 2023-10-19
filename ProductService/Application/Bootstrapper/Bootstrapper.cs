using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ProductService.Application.Contract.Request.Product;
using ProductService.Application.Interfaces.Repositories;
using ProductService.Application.Interfaces.Services;
using ProductService.Application.Interfaces.UnitOfWork;
using ProductService.Application.Validators;
using ProductService.Persistence.Context.EntityFramework;
using ProductService.Persistence.Implementations.Repositories;
using ProductService.Persistence.Implementations.Services;
using ProductService.Persistence.Implementations.UnitOfWork;
using Shared.Resources;

namespace ProductService.Application.Bootstrapper
{
    public static class Bootstrapper
    {
        public static void AddPersistenceServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            #region Services
            services.AddDbContext<ProductDdContext>(x => x.UseSqlServer(configuration.GetConnectionString("ProductServiceConString")));

            services.AddScoped<IProductService, Persistence.Implementations.Services.ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();



            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();




            services.AddScoped<IResourceService, ResourceService>();
            #endregion
            services.AddScoped<IValidator<CreateProductRequest>, ProductValidator>();
            #region UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion
        }
    }
}
