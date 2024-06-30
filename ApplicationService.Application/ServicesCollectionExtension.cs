using System.Reflection;
using ApplicationService.Application.Behaviours;
using FluentValidation;
using KDS.Primitives.FluentResult;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationService.Application;

public static class ServicesCollectionExtension
{
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}