using ProductService.Application.Contract.Response.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Contract.Request.Category
{
    public class CreateCategoryRequest
    {
        public string Name { get; set; }

        public CreateCategoryResponse MapToPaylod(Domain.Entities.Category category)
        {
            return new CreateCategoryResponse { Id = category.Id, Name = category.Name, CreatedOn = category.CreatedOn };
        }
        public Domain.Entities.Category MapToEntity()
        {
            return new ProductService.Domain.Entities.Category()
            {
                Name = Name

            };
        }
    }
}
