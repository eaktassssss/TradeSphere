using Identity.Application.Contract.Request.User;
using Identity.Application.Contract.Response.User;
using Identity.Application.Interfaces.Services;
using Identity.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shared.Resources;
using Shared.Wrappers;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Persistence.Implementations.Services
{
    public class UserService : IUserService
    {

        private readonly UserManager<User> _userManager;
        private readonly IResourceService _resourceService;
        public UserService(UserManager<User> userManager, IResourceService resourceService)
        {
            _userManager = userManager;
            _resourceService = resourceService;
        }
        public async Task<ServiceDataResponse<CreateUserResponse>> CreateAsync(CreateUserRequest createUserRequest)
        {
            ServiceDataResponse<CreateUserResponse> serviceDataResponse = new ServiceDataResponse<CreateUserResponse>();
            User user = createUserRequest.MapToEntity();

            
                var result = await _userManager.CreateAsync(user, createUserRequest.Password);
                switch (result.Succeeded)
                {
                    case true:
                        serviceDataResponse.Message = _resourceService.GetResource("OPERATION_SUCCESS");
                        serviceDataResponse.StatusCode = 200;
                        serviceDataResponse.Success = true;
                        serviceDataResponse.Paylod = createUserRequest.MapToPaylod(user);
                        break;

                    case false:
                        serviceDataResponse.Message = _resourceService.GetResource("OPERATION_FAILED");
                        serviceDataResponse.StatusCode = 500;
                        serviceDataResponse.Success = false;
                        break;
                }
            return serviceDataResponse;
        }
        public async Task<ServiceDataResponse<GetSingleUserResponse>> GetSingleAsync(string id)
        {
            ServiceDataResponse<GetSingleUserResponse> serviceDataResponse = new ServiceDataResponse<GetSingleUserResponse>();
            User user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                serviceDataResponse.Message = _resourceService.GetResource("RESOURCE_NOT_FOUND");
                serviceDataResponse.StatusCode = 404;
                serviceDataResponse.Success = false;
                return serviceDataResponse;
            }

            GetSingleUserResponse getSingleCustomerResponse = new GetSingleUserResponse();
            serviceDataResponse.Message = _resourceService.GetResource("DATA_RETRIEVED_SUCCESSFULLY");
            serviceDataResponse.StatusCode = 200;
            serviceDataResponse.Success = true;
            serviceDataResponse.Paylod = new GetSingleUserResponse().MapToPaylod(user);
            return serviceDataResponse;
        }

        
        public async Task<ServiceDataResponse<UpdateUserResponse>> UpdateAsync(UpdateUserRequest updateUserRequest)
        {
            ServiceDataResponse<UpdateUserResponse> serviceDataResponse = new ServiceDataResponse<UpdateUserResponse>();
            User user = await _userManager.FindByIdAsync(updateUserRequest.Id);
            if (user == null)
            {
                serviceDataResponse.Message = _resourceService.GetResource("RESOURCE_NOT_FOUND");
                serviceDataResponse.StatusCode = 404;
                serviceDataResponse.Success = false;
                return serviceDataResponse;
            }

            var result = await _userManager.UpdateAsync(updateUserRequest.MapToEntity(user));
            switch (result.Succeeded)
            {
                case true:
                    serviceDataResponse.Message = _resourceService.GetResource("OPERATION_SUCCESS");
                    serviceDataResponse.StatusCode = 200;
                    serviceDataResponse.Success = true;
                    serviceDataResponse.Paylod = updateUserRequest.MapToPaylod(user);
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
