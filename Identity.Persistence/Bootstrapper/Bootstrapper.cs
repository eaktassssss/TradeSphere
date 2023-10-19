using Identity.Application.Configuration;
using Identity.Application.Interfaces.Services;
using Identity.Application.Interfaces.UnitOfWork;
using Identity.Domain.Entities;
using Identity.Persistence.Context.EntityFramework;
using Identity.Persistence.Implementations.Services;
using Identity.Persistence.Implementations.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Shared.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Persistence.Bootstrapper
{
    public static class Bootstrapper
    {
        public static void AddPersistenceServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            #region Services
            services.AddDbContext<IdentityContext>(x => x.UseSqlServer(configuration.GetConnectionString("IdentityServiceConString")));
            services.AddIdentity<User, Role>().AddEntityFrameworkStores<IdentityContext>();

            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            var settings = configuration.GetSection("JwtSettings").Get<JwtSettings>();

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(settings.Key)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidIssuer = settings.Issuer,
                    ValidAudience = settings.Audience
                };
            });


            services.AddScoped<IResourceService, ResourceService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            #endregion
            #region UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion
        }
    }
}
