using NN.Digi.Store.Domain;
using NN.Digi.Store.Infrastructure.Mongo;
using NN.Digi.Store.Infrastructure.Repository;

namespace NN.Digi.Store.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ApplicationSetting setting)
    {
        services.AddMongo(setting)
            .AddRepository();
        return services;
    }
}
