using System.Threading.Tasks;
using Lib.Cosmos.Apis.OpResponses;
using Microsoft.Azure.Cosmos;

namespace Lib.Cosmos.Apis.Adapters;

internal interface ICosmosContainerDeleteAdapter
{
    Task<OpResponse<T>> DeleteItemAsync<T>(Container container, DeletePointItem item);
}

public interface ICosmosContainerReadItemAdapter
{
    Task<OpResponse<T>> ReadItemAsync<T>(Container container, ReadPointItem item);
}
