using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;

namespace Lib.Cosmos.Apis;

public interface ICosmosContainerUpsertAdapter
{
    Task<OpResponse<T>> UpsertItemAsync<T>(Container container, T item);
}
