using Order.Persistence.Bootstrapper;
using Order.Application.Bootstrapper;
using Order.Application.Features.Commands.Request;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistenceServiceRegistration(builder.Configuration);
builder.Services.AddApplicationServiceRegistration(builder.Configuration);
builder.Services.AddMediatR(x =>
{
    x.RegisterServicesFromAssemblyContaining<CreateOrderCommandRequest>();
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
