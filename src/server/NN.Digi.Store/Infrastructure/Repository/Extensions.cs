using NN.Digi.Store.Domain.Repository;

namespace NN.Digi.Store.Infrastructure.Repository
{
    public static class Extensions
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.Scan(scan => scan.FromAssemblyOf<IRepository>()
                    .AddClasses(classes => classes.AssignableTo<IRepository>())
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());

            return services;
        }
    }
}
