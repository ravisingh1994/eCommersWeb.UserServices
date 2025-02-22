using eCommerce.Core.RepositoryContract;
using eCommerce.Infrastructure.DbContext;
using eCommerce.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infrastructure;
public static class DependancyInjection
{  /// <summary>
///   add all the Service object to IOC Container
/// </summary>
/// <param name="services"></param>
/// <returns></returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IUsersRepository, UsersRepository>();
        services.AddTransient<DapperDbContext>();
        return services;

    }
}

