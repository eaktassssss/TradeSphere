﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Application.Contract.Request.Product;
using ProductService.Application.Interfaces.Services;

namespace ProductService.Controllers.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpPost]
        [Route("product")]
        public async Task<IActionResult> CreateAsync(CreateProductRequest  createProductRequest)
        {
            var response = await _productService.CreateAsync(createProductRequest);
            return Ok(response);
        }
    }
}
