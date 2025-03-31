using Lib.Cosmos.Primitives;
using Lib.Universal.Primitives;

namespace Lib.Cosmos.Tests.Primitives;

[TestClass]
public sealed class CosmosAccountNameTests
{
    [TestMethod, TestCategory("unit")]
    public void CosmosAccountName_ShouldExist()
    {
        //arrange

        //act
        ToSystemType<string> _ = new CosmosAccountName();

        //assert

    }

    [TestMethod, TestCategory("unit")]
    public void AsSystemType_ShouldReturnExpected()
    {
        //arrange
        CosmosAccountName subject = new TestCosmosAccountName();

        //act
        string actual = subject.AsSystemType();

        //assert
        _ = actual.Should().Be("potato");
    }

    private sealed class TestCosmosAccountName : CosmosAccountName { }
}
