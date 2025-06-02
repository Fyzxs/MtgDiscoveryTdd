using Lib.Cosmos.Adapters;
using Lib.Cosmos.Apis.Adapters;
using Lib.Cosmos.Tests.Fakes;

namespace Lib.Cosmos.Tests.Adapters;

[TestClass]
public sealed class CosmosContainerDeleteAdapterTests
{
    [TestMethod, TestCategory("unit")]
    public void Should_Exist()
    {
        //arrange

        //act
        LoggerFake loggerFake = new();
        ICosmosContainerDeleteAdapter _ = new CosmosContainerDeleteAdapter(loggerFake);

        //assert
    }
}
