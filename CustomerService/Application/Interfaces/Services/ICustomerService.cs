using CustomerService.Application.Contract.Request.Customer;
using CustomerService.Application.Contract.Response.Customer;
using Shared.Wrappers;

namespace CustomerService.Application.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<ServiceDataResponse<CreateCustomerResponse>> CreateAsync(CreateCustomerRequest createCustomerRequest);
        Task<ServiceDataResponse<GetSingleCustomerResponse>> GetSingleAsync(int id);
    }
}
