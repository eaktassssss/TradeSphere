using Shared.Resources;
using Shared.Wrappers;
using StockService.Application.Contract.Request;
using StockService.Application.Contract.Response;
using StockService.Application.Interfaces.Repositories;
using StockService.Application.Interfaces.Services;
using StockService.Domain.Entities;
using static MassTransit.ValidationResultExtensions;

namespace StockService.Persistence.Implementations.Services
{
    public class StockService : IStockService
    {
        private readonly IResourceService _resourceService;
        private readonly IStockRepository _stockRepository;
        public StockService(IResourceService resourceService, IStockRepository stockRepository)
        {
            _resourceService = resourceService;
            _stockRepository = stockRepository;
        }
        public async Task<ServiceDataResponse<CreateStockResponse>> CreateAsync(CreateStockRequest createStockRequest)
        {
            ServiceDataResponse<CreateStockResponse> serviceResponse = new ServiceDataResponse<CreateStockResponse>();
            bool isOPerationSuccess = false;
            var stock = await _stockRepository.GetAsync(x => x.ProductId == createStockRequest.ProductId);
            if (stock != null)
            {
                stock.ProductId = createStockRequest.ProductId;
                stock.Count = createStockRequest.Count;
                var updateStock = _stockRepository.UpdateAsync(stock.Id, stock);
                serviceResponse.Paylod = createStockRequest.MapToPaylod(stock);
                if (updateStock != null)
                    isOPerationSuccess = true;
                else
                    isOPerationSuccess = false;
            }
            else
            {
                Stock newStock = createStockRequest.MapToEntity();
                Stock createStock = await _stockRepository.InsertAsync(newStock);
                serviceResponse.Paylod = createStockRequest.MapToPaylod(createStock);
                if (createStock != null)
                    isOPerationSuccess = true;
                else
                    isOPerationSuccess = false;
            }

            switch (isOPerationSuccess)
            {
                case true:
                    serviceResponse.Success = true;
                    serviceResponse.StatusCode = 200;
                    serviceResponse.Message = _resourceService.GetResource("OPERATION_FAILED");

                    break;
                case false:
                    serviceResponse.Success = false;
                    serviceResponse.StatusCode = 500;
                    serviceResponse.Message = _resourceService.GetResource("OPERATION_FAILED");
                    serviceResponse.Paylod = null;
                    break;
            }
            return serviceResponse;
        }
    }
}
