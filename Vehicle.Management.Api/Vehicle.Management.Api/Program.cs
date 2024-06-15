using Vehicle.Management.Infra.IoC;
using Vehicle.Management.Api.Configurations;
using Vehicle.Management.Api.Validations;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<MotorcyclePostRequestValidator>();

builder.Services.ConfigureContainer();
builder.Services.AddConfigurations(configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();