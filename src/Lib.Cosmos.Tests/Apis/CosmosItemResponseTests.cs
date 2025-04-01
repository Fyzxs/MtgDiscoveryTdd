using System.Reflection;
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

    [TestMethod, TestCategory("unit")]
    public void Value_PropertyShouldBeGetOnly()
    {
        //arrange
        PropertyInfo propertyInfo = typeof(CosmosItemResponse<object>).GetProperty("Value");

        //act
        bool hasGetter = propertyInfo?.CanRead == true;
        bool hasSetter = propertyInfo?.CanWrite == true;

        //assert
        _ = hasGetter.Should().BeTrue("Value property should have a getter");
        _ = hasSetter.Should().BeFalse("Value property should not have a setter");
    }

    [TestMethod, TestCategory("unit")]
    public void Value_ShouldBeVirtual()
    {
        //arrange
        PropertyInfo propertyInfo = typeof(CosmosItemResponse<object>).GetProperty("Value");

        //act
        bool isVirtual = propertyInfo?.GetMethod?.IsVirtual == true && !propertyInfo.GetMethod.IsFinal;

        //assert
        _ = isVirtual.Should().BeTrue("Value property should be virtual");
    }

    private sealed class TestCosmosItemResponse<T> : CosmosItemResponse<T>
    {

        public override T AsSystemType() => throw new System.NotImplementedException();
    }
}
