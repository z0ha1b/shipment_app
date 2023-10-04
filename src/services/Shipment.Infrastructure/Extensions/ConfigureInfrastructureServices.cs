using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shipment.Core.Repositories;
using Shipment.Infrastructure.Data;
using Shipment.Infrastructure.Repositories;

namespace Shipment.Infrastructure.Extensions;

public static class ConfigureInfrastructureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<OrderContext>(options => options.UseSqlServer(configuration.GetConnectionString("OrderConnectionString")));
        serviceCollection.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
        serviceCollection.AddScoped<IOrderRepository, OrderRepository>();

        return serviceCollection;
    }
}