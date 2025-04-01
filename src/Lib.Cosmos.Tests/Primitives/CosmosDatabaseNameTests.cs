using Lib.Cosmos.Primitives;
using Lib.Universal.Primitives;
using TestConvenience.Universal.Tests;

namespace Lib.Cosmos.Tests.Primitives
{

    [TestClass]
    public sealed class CosmosDatabaseNameTests : BaseToSystemTypeTests<CosmosDatabaseName, string>;

    [TestClass]
    public sealed class CosmosCollectionNameTests : BaseToSystemTypeTests<CosmosCollectionName, string>;
}

namespace Lib.Cosmos.Primitives
{
    public abstract class CosmosCollectionName : ToSystemType<string>;
}
