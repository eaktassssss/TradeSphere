using ProductService.Application.Contract.Request.Product;
using ProductService.Application.Contract.Response.Product;
using Shared.Wrappers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<ServiceDataResponse<CreateProductResponse>> CreateAsync(CreateProductRequest createProductRequest);
    }
}
