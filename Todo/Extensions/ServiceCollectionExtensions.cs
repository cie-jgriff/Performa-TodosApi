
using Todo.Domain.Stores;
using Todo.Infrastructure.Stores;

namespace Todo.Extensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCore(this IServiceCollection services, HttpClient httpClient)
    {
        services.AddSingleton(httpClient)
            .AddScoped<ITodoStore, TodoStore>()
            .AddAutoMapper(cfg => cfg.AddMaps(typeof(Program).Assembly))
            .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

        return services;
    }
}
