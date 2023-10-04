using Shipment.Core.Entities;
using Shipment.Core.Repositories;
using Shipment.Infrastructure.Data;

namespace Shipment.Infrastructure.Repositories;

public class OrderRepository : RepositoryBase<Order>, IOrderRepository
{
    public OrderRepository(OrderContext dbContext) : base(dbContext)
    {
    }
}