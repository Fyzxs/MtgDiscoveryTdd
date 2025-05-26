using Lib.Cosmos.Tests.Fakes;
using Microsoft.Extensions.Logging;

namespace Lib.Cosmos.Tests.Adapters;

[TestClass]
public sealed class CosmosContainerQueryAdapterTests
{
    [TestMethod, TestCategory("unit")]
    public void Should_Exist()
    {
        //arrange

        //act
        LoggerFake loggerFake = new();
        ICosmosContainerQueryAdapter _ = new CosmosContainerQueryAdapter(loggerFake);

        //assert
    }
}

public sealed class CosmosContainerQueryAdapter : ICosmosContainerQueryAdapter
{
    public CosmosContainerQueryAdapter(ILogger logger)
    {
        throw new System.NotImplementedException();
    }
}

public interface ICosmosContainerQueryAdapter
{
}
