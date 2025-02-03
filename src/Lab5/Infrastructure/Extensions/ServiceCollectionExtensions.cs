using Application.Abstraction.Repositories;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureDataAccess(
        this IServiceCollection collection)
    {
        collection.AddScoped<IAccountRepository, AccountRepository>();
        collection.AddScoped<IAdminRepository, AdminRepository>();
        return collection;
    }
}