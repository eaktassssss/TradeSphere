using ProductService.Application.Contract.Request.Category;
using ProductService.Application.Contract.Response.Category;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<ServiceDataResponse<CreateCategoryResponse>> CreateAsync(CreateCategoryRequest createCategoryRequest);
    }
}
