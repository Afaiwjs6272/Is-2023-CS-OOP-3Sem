using Application.Application.Extensions;
using Infrastructure.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Presentation;
using Presentation.Extensions;

var collection = new ServiceCollection();
collection
    .AddApplication()
    .AddInfrastructureDataAccess()
    .AddPresentation();
ServiceProvider provider = collection.BuildServiceProvider();

provider.GetService<IPresentationConsole>()?.Run();