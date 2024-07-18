using Microsoft.Extensions.DependencyInjection.Extensions;
using Todo.Interfaces;

namespace Todo.Extensions;

public static class EndpointExtensions
{
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