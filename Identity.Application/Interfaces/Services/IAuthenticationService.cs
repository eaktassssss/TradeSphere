using Identity.Application.Contract.Request.Token;
using Identity.Application.Contract.Response.Token;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<ServiceDataResponse<CreateTokenResponse>> CreateTokenAsync(CreateTokenRequest createTokenRequest);
    }
}
