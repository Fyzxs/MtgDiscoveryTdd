using Lib.Cosmos.Apis.Adapters;

namespace Lib.Cosmos.Tests.Fakes;

public sealed class CosmosClientAdapterFactoryFake : ICosmosClientAdapterFactory
{
    public ICosmosClientAdapter InstanceResponse { get; init; }
    public int InstanceInvokeCount { get; private set; }

    public ICosmosClientAdapter Instance()
    {
        InstanceInvokeCount++;
        return InstanceResponse;
    }
}