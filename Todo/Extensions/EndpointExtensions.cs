using Microsoft.Extensions.DependencyInjection.Extensions;
using Todo.Interfaces;

namespace Todo.Extensions;

public static class EndpointExtensions
{
    /// <summary>
    /// Registers all implementations of <see cref="IModule"/> in the current assembly to the service collection
    /// </summary>
    /// <param name="services"></param>
    public static IServiceCollection AddEndpoints(this IServiceCollection services)
    {
        var assembly = typeof(Program).Assembly;
        var serviceDescriptors = assembly
            .DefinedTypes
            .Where(type => type is { IsAbstract: false, IsInterface: false } &&
                           type.IsAssignableTo(typeof(IModule)))
            .Select(type => ServiceDescriptor.Transient(typeof(IModule), type));
        services.TryAddEnumerable(serviceDescriptors);
        return services;
    }

    /// <summary>
    /// Loops through all registered <see cref="IModule"/> instances and maps their endpoints
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static WebApplication MapEndpoints(this WebApplication app)
    {
        var modules = app.Services.GetRequiredService<IEnumerable<IModule>>();

        foreach (var module in modules)
        {
            module.MapEndpoints(app);
        }

        return app;
    }
}