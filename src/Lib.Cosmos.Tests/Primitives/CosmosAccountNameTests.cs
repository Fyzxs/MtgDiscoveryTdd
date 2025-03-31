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
        CosmosAccountName subject = new TestCosmosAccountName("potato");

        //act
        string actual = subject.AsSystemType();

        //assert
        _ = actual.Should().Be("potato");
    }

    [TestMethod, TestCategory("unit")]
    public void AsSystemType_ShouldReturnProvided()
    {
        //arrange
        CosmosAccountName subject = new TestCosmosAccountName("new_value");

        //act
        string actual = subject.AsSystemType();

        //assert
        _ = actual.Should().Be("new_value");
    }

    private sealed class TestCosmosAccountName : CosmosAccountName
    {
        private readonly string _origin;

        public TestCosmosAccountName(string origin) => _origin = origin;

        public override string AsSystemType() => _origin;
    }
}
