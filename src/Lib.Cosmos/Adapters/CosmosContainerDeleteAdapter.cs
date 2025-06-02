using Lib.Cosmos.Apis.Adapters;
using Microsoft.Extensions.Logging;

namespace Lib.Cosmos.Adapters;

internal sealed class CosmosContainerDeleteAdapter : ICosmosContainerDeleteAdapter
{
    private readonly ILogger _logger;

    public CosmosContainerDeleteAdapter(ILogger logger) => _logger = logger;
}
