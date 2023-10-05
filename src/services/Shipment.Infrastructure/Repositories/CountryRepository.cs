using Shipment.Core.Entities;
using Shipment.Core.Repositories;
using Shipment.Infrastructure.Data;

namespace Shipment.Infrastructure.Repositories;

public class CountryRepository : RepositoryBase<Country>, ICountryRepository
{
    public CountryRepository(OrderContext dbContext) : base(dbContext)
    {
    }
}