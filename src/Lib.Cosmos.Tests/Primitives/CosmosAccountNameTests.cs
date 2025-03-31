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
}