using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ocelot.Values;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var authenticationProviderKey = "IdentityKey";

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(authenticationProviderKey, options =>
    {
        options.Authority = "https://localhost:7270"; // Identity servisinizin URL'si
        options.Audience = "yourApiResourceName"; // JWT token oluşturulurken belirlediğiniz Audience değeri.
        options.RequireHttpsMetadata = true; // HTTPS zorunluluğu, lokalde çalışırken false yapabilirsiniz.
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true
        };
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
