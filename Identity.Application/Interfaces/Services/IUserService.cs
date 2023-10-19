
using Identity.Application.Contract.Request.User;
using Identity.Application.Contract.Response.User;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<ServiceDataResponse<CreateUserResponse>> CreateAsync(CreateUserRequest createUserRequest);
        Task<ServiceDataResponse<UpdateUserResponse>> UpdateAsync(UpdateUserRequest updateUserRequest);
        Task<ServiceDataResponse<GetSingleUserResponse>> GetSingleAsync(string id);
         

    }
}
