using PaymentService.Application.Contract.Request;
using PaymentService.Application.Contract.Response;
using PaymentService.Application.Interfaces.Repositories;
using PaymentService.Domain.Entities;
using Shared.Wrappers;

namespace PaymentService.Application.Interfaces.Operations
{
    public interface IPaymentService
    {
        Task<ServiceDataResponse<CreatePaymentResponse>> CreateAsync(CreatePaymentRequest createPaymentRequest);
    }
}
