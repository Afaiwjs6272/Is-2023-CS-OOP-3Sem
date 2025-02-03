using Microsoft.Extensions.DependencyInjection;

namespace Presentation.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentation(this IServiceCollection collection)
    {
        collection.AddScoped<IPresentationConsole, MyPresentationConsole>();
        return collection;
    }
}