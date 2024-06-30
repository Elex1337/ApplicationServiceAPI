using System.Text.Json.Serialization;
using ApplicationService.Application;
using ApplicationService.Infrastructure;
using ApplicationServiceAPI;
using ApplicationServiceAPI.CustomMiddlewares;

var builder = WebApplication.CreateBuilder(args);


builder.Services.ConfigureLogging(builder.Configuration);

builder.Services.ConfigureApplicationServices();


builder.Services.ConfigureDataBase(builder.Configuration);

builder.Services.AddInfrastructureServices();


builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();