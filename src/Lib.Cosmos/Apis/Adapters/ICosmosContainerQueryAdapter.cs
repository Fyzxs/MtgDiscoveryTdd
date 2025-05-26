using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;

namespace Lib.Cosmos.Apis.Adapters;

public interface ICosmosContainerQueryAdapter
{
    Task<IEnumerable<T>> QueryAsync<T>(Container container, QueryDefinition queryDefinition, PartitionKey partitionKey, CancellationToken cancellationToken = default);
}
