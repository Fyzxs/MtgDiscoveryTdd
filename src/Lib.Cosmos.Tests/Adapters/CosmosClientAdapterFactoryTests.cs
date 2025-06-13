using Lib.Cosmos.Adapters;
using Lib.Cosmos.Apis.Adapters;
using Lib.Cosmos.Tests.Fakes;

namespace Lib.Cosmos.Tests.Adapters;

[TestClass]
public sealed class CosmosClientAdapterFactoryTests
{
    [TestMethod, TestCategory("unit")]
    public void Should_Exist()
    {
        //arrange

        //act
        ICosmosClientAdapterFactory _ = new CosmosClientAdapterFactory();

        //assert
    }

    [TestMethod, TestCategory("unit")]
    public void Instance_ShouldReturnICosmosClientAdapter()
    {
        //arrange
        CosmosClientAdapterFactory subject = new();
        CosmosAccountNameFake accountNameFake = new("test-account");

        //act
        ICosmosClientAdapter actual = subject.Instance(accountNameFake);

        //assert
        _ = actual.Should().NotBeNull();
        _ = actual.Should().BeOfType<CosmosClientAdapter>();
    }

    [TestMethod, TestCategory("unit")]
    public void Instance_ShouldReturnDifferentInstancesForDifferentCalls()
    {
        //arrange
        CosmosClientAdapterFactory subject = new();
        CosmosAccountNameFake accountNameFake = new("test-account");

        //act
        ICosmosClientAdapter actual1 = subject.Instance(accountNameFake);
        ICosmosClientAdapter actual2 = subject.Instance(accountNameFake);

        //assert
        _ = actual1.Should().NotBeSameAs(actual2);
    }
}