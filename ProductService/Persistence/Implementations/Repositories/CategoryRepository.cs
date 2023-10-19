using ProductService.Application.Interfaces.Repositories;
using ProductService.Domain.Entities;
using ProductService.Persistence.Context.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Persistence.Implementations.Repositories
{
    public class CategoryRepository : EfRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ProductDdContext productDbContext) : base(productDbContext)
        {
        }
    }
}
