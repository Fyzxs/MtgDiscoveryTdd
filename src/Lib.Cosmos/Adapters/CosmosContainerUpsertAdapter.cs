using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;

namespace Lib.Cosmos.Adapters;

public sealed class CosmosContainerUpsertAdapter : ICosmosContainerUpsertAdapter
{
    public void Foo() => throw new System.NotImplementedException();

    public async Task<ItemResponse<T>> UpsertItemAsync<T>([NotNull] Container container, T item)
    {
        return await container.UpsertItemAsync(item).ConfigureAwait(false);
    }
}
