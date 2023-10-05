using Shipment.Core.Entities;

namespace Shipment.Core.Repositories;

public interface IStateRepository : IAsyncRepository<State>
{
    Task<IReadOnlyList<State>> GetStates(long countryId);
}