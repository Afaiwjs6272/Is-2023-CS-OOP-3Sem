using Application.Application.Accounts;
using Application.Application.Admin;
using Application.Contracts.Accounts;
using Application.Contracts.Admin;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IAccountService, AccountService>();
        collection.AddScoped<IAdminService, AdminService>();

        return collection;
    }
}