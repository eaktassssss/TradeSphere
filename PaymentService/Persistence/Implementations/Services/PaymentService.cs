using Amazon.Runtime.Internal.Util;
using PaymentService.Application.Contract.Request;
using PaymentService.Application.Contract.Response;
using PaymentService.Application.Interfaces.Operations;
using PaymentService.Application.Interfaces.Repositories;
using PaymentService.Domain.Entities;
using Shared.Resources;
using Shared.Wrappers;

namespace PaymentService.Persistence.Implementations.Operations
{
    public class PaymentService : IPaymentService
    {
        private readonly IResourceService _resourceService;
        private readonly IPaymentRepository _repository;
        public PaymentService(IPaymentRepository repository, IResourceService resourceService)
        {
            _repository = repository;
            _resourceService = resourceService;
        }
        public async Task<ServiceDataResponse<CreatePaymentResponse>> CreateAsync(CreatePaymentRequest createPaymentRequest)
        {

            ServiceDataResponse<CreatePaymentResponse> serviceResponse = new ServiceDataResponse<CreatePaymentResponse>();

            Payment payment = createPaymentRequest.MapToEntity();
            Payment result = await _repository.InsertAsync(payment);
            if (result != null)
            {
                serviceResponse.Success = true;
                serviceResponse.Message = _resourceService.GetResource("OPERATION_SUCCESS");
                serviceResponse.Paylod = createPaymentRequest.MapToPaylod(payment);
                return serviceResponse;
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = _resourceService.GetResource("OPERATION_FAILED");
                serviceResponse.Paylod = null;
                return serviceResponse;
            }
        }
    }
}
