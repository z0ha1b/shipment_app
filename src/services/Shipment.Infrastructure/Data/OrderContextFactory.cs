using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shipment.Infrastructure.Data;

public class SchedulingContextFactory : IDesignTimeDbContextFactory<OrderContext>
{
    public OrderContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<OrderContext>();
        optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=OrderDb;TrustServerCertificate=true;Trusted_Connection=True;MultipleActiveResultSets=true");

        return new OrderContext(optionsBuilder.Options);
    }
}