using Shared.Wrappers;
using StockService.Application.Contract.Request;
using StockService.Application.Contract.Response;

namespace StockService.Application.Interfaces.Services
{
    public interface IStockService
    {
        Task<ServiceDataResponse<CreateStockResponse>> CreateAsync(CreateStockRequest  createStockRequest);
    }
}
