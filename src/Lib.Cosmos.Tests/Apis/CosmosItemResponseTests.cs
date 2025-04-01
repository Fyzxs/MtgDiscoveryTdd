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
        CosmosItemResponse<object> subject = new TestCosmosItemResponse<object>(null);

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
        bool isVirtual = propertyInfo!.GetMethod!.IsAbstract && propertyInfo.GetMethod.IsFinal is false;

        //assert
        _ = isVirtual.Should().BeTrue("Value property should be virtual");
    }

    private sealed class TestCosmosItemResponse<T> : CosmosItemResponse<T>
    {
        public TestCosmosItemResponse(T origin)
        {
            Value = origin;
        }

        public override T Value { get; }

        public override T AsSystemType() => throw new System.NotImplementedException();
    }
}
