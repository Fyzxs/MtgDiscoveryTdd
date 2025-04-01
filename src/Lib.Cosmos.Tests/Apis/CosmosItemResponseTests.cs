using Lib.Cosmos.Apis;
using TestConvenience.Universal.Tests;

namespace Lib.Cosmos.Tests.Apis;

[TestClass]
public class CosmosItemResponseTests : BaseToSystemTypeTests<CosmosItemResponse<object>, object>
{
    [TestMethod, TestCategory("unit")]
    public void Value_PropertyShouldExist()
    {
        //arrange
        CosmosItemResponse<object> subject = new TestCosmosItemResponse<object>();

        //act
        object _ = subject.Value;

        //assert
    }
    private sealed class TestCosmosItemResponse<T> : CosmosItemResponse<T>
    {
        public override T AsSystemType() => throw new System.NotImplementedException();
    }
}
