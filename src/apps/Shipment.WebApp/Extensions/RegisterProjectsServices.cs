using Shipment.Application.Extensions;
using Shipment.Infrastructure.Extensions;

namespace Shipment.WebApp.Extensions;

public static class RegisterProjectsServices
{
    public static IServiceCollection AddProjectsServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddApplicationServices();
        serviceCollection.AddInfrastructureServices(configuration);

        return serviceCollection;
    }
}