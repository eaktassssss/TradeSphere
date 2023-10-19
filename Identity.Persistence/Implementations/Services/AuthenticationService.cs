
using Identity.Application.Configuration;
using Identity.Application.Contract.Request.Token;
using Identity.Application.Contract.Response.Token;
using Identity.Application.Interfaces.Services;
using Identity.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shared.Resources;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Persistence.Implementations.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IResourceService _resourceService;
        public AuthenticationService(IConfiguration configuration, IResourceService resourceService, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _configuration = configuration;
            _userManager = userManager;
            _resourceService = resourceService;
            _signInManager = signInManager;
        }
        public async Task<ServiceDataResponse<CreateTokenResponse>> CreateTokenAsync(CreateTokenRequest createTokenRequest)
        {
            ServiceDataResponse<CreateTokenResponse> serviceResponse = new ServiceDataResponse<CreateTokenResponse>();

            var jwtSettings = _configuration.GetSection("JwtSettings").Get<JwtSettings>();
            var key = Encoding.ASCII.GetBytes(jwtSettings.Key);

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == createTokenRequest.UserName);

            if (user == null)
            {
                serviceResponse.Message = _resourceService.GetResource("USER_NOT_FOUND");
                serviceResponse.StatusCode = 404;
                serviceResponse.Success = false;
                return serviceResponse;
            }



            var verifyPassword = await _signInManager.CheckPasswordSignInAsync(user, createTokenRequest.Password, false);
            if (!verifyPassword.Succeeded)
            {
                serviceResponse.Message = _resourceService.GetResource("INVALID_PASSWORD");
                serviceResponse.StatusCode = 500;
                serviceResponse.Success = false;
                return serviceResponse;
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
               {
                new Claim(ClaimTypes.Name, createTokenRequest.UserName),
                new Claim(ClaimTypes.Email,user.Email)
               }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = jwtSettings.Issuer,
                Audience = jwtSettings.Audience
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            CreateTokenResponse createTokenResponse = new CreateTokenResponse();
            createTokenResponse.Token = tokenHandler.WriteToken(token);
            createTokenResponse.ExperiDate = (DateTime)tokenDescriptor.Expires;
            serviceResponse.StatusCode = 200;
            serviceResponse.Success = true;
            serviceResponse.Paylod = createTokenResponse;
            serviceResponse.Message = _resourceService.GetResource("OPERATION_SUCCESS");
            return serviceResponse;

        }
    }
}
