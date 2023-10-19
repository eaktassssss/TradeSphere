using ProductService.Application.Interfaces.Repositories;
using ProductService.Domain.Entities;
using ProductService.Persistence.Context.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Persistence.Implementations.Repositories
{
    public class ProductRepository : EfRepository<Product>, IProductRepository
    {
        public ProductRepository(ProductDdContext productDbContext) : base(productDbContext)
        {
        }
    }
}
