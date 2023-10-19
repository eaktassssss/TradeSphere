using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Application.Contract.Request.Category;
using ProductService.Application.Interfaces.Services;

namespace ProductService.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpPost]
        [Route("category")]
        public async Task<IActionResult> CreateAsync(CreateCategoryRequest createCategoryRequest)
        {
            var response =await _categoryService.CreateAsync(createCategoryRequest);
            return Ok(response);
        }
    }
}
