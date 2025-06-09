using Lib.Cosmos.Apis.Adapters;
using Lib.Cosmos.Apis.Ids;

namespace Lib.Cosmos.Tests.Fakes;

public sealed class CosmosClientAdapterFactoryFake : ICosmosClientAdapterFactory
{
    public ICosmosClientAdapter InstanceResponse { get; init; }
    public int InstanceInvokeCount { get; private set; }
    public CosmosAccountName LastAccountName { get; private set; }

    public ICosmosClientAdapter Instance(CosmosAccountName accountName)
    {
        InstanceInvokeCount++;
        LastAccountName = accountName;
        return InstanceResponse;
    }
}
