using Microsoft.EntityFrameworkCore;
using Shipment.Core.Entities;
using Shipment.Core.Repositories;
using Shipment.Infrastructure.Data;

namespace Shipment.Infrastructure.Repositories;

public class StateRepository : RepositoryBase<State>, IStateRepository
{
    public StateRepository(OrderContext dbContext) : base(dbContext)
    {
    }

    public async Task<IReadOnlyList<State>> GetStates(string country)
    {
        try
        {
            var statesList = await DbContext.Set<State>().Where(x => x.Abbr.Equals(country)).ToListAsync();
            if (statesList.Count == 0)
            {
                 var allStates = await DbContext.Set<State>().ToListAsync();
                 return  allStates;
            }
            return statesList;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error while finding states " + e);
            throw;
        }
   
    }
}