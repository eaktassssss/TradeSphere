using ProductService.Application.Contract.Request.Category;
using ProductService.Application.Contract.Response.Category;
using ProductService.Application.Interfaces.Repositories;
using ProductService.Application.Interfaces.Services;
using ProductService.Application.Interfaces.UnitOfWork;
using Shared.Resources;
using Shared.Wrappers;

namespace ProductService.Persistence.Implementations.Services
{
    public class CategoryService : ICategoryService
    {
        ICategoryRepository _categoryRepository;
        IResourceService _resourceService;
        readonly IUnitOfWork _unitOfWork;
        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IResourceService resourceService)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _resourceService = resourceService;
        }


        public async Task<ServiceDataResponse<CreateCategoryResponse>> CreateAsync(CreateCategoryRequest createCategoryRequest)
        {
            ServiceDataResponse<CreateCategoryResponse> serviceDataResponse = new ServiceDataResponse<CreateCategoryResponse>();

            var categoryCheck = await _categoryRepository.GetSingleAsync(x => x.Name.Trim().ToLower() == createCategoryRequest.Name.Trim().ToLower());
            if (categoryCheck != null)
            {
                serviceDataResponse.Success = false;
                serviceDataResponse.Message = _resourceService.GetResource("ALREADY_EXISTS");
                serviceDataResponse.StatusCode = 409;
                return serviceDataResponse;
            }
            var category = createCategoryRequest.MapToEntity();
            await _categoryRepository.AddAsync(category);

            var result = await _unitOfWork.CommitAsync();
            switch (result)
            {
                case true:
                    serviceDataResponse.Message = _resourceService.GetResource("OPERATION_SUCCESS");
                    serviceDataResponse.StatusCode = 200;
                    serviceDataResponse.Success = true;
                    serviceDataResponse.Paylod = createCategoryRequest.MapToPaylod(category);
                    break;

                case false:
                    serviceDataResponse.Message = _resourceService.GetResource("OPERATION_FAILED");
                    serviceDataResponse.StatusCode = 500;
                    serviceDataResponse.Success = false;
                    break;
            }
            return serviceDataResponse;

        }
    }
}
