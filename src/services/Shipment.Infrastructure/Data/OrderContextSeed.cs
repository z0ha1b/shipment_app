using Microsoft.Extensions.Logging;

namespace Shipment.Infrastructure.Data;

public class OrderContextSeed
{
    public static async Task SeedAsync(OrderContext context, ILogger<OrderContextSeed> logger)
    {
        if (!context.Orders.Any())
        {
            // context.Appointments.AddRange(GetAppointments());
            await context.SaveChangesAsync();
        
            logger.LogInformation($"Order Database seeded.");
        }
    }
}