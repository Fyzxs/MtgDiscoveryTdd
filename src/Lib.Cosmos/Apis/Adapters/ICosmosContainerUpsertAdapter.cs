using System.Threading.Tasks;
using Lib.Cosmos.Apis.OpResponses;
using Microsoft.Azure.Cosmos;

namespace Lib.Cosmos.Apis.Adapters;

public interface ICosmosContainerUpsertAdapter
{
    Task<OpResponse<T>> UpsertItemAsync<T>(Container container, T item);
}
