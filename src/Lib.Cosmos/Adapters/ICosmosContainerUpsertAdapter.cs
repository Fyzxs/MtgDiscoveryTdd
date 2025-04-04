using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Lib.Cosmos.Apis;
using Microsoft.Azure.Cosmos;

namespace Lib.Cosmos.Adapters;

public interface ICosmosContainerUpsertAdapter
{
    void Foo();
    Task<OpResponse<T>> UpsertItemAsync<T>([NotNull] Container container, T item);
}
