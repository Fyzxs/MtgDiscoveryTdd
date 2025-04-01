using System.Net;
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
        CosmosItemResponse<object> subject = new TestCosmosItemResponse<object>(null, HttpStatusCode.OK);

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
    public void Value_ShouldBeAbstract()
    {
        //arrange
        PropertyInfo propertyInfo = typeof(CosmosItemResponse<object>).GetProperty("Value");

        //act
        bool actual = propertyInfo!.GetMethod!.IsAbstract && propertyInfo.GetMethod.IsFinal is false;

        //assert
        _ = actual.Should().BeTrue("Value property should be abstract");
    }

    [TestMethod, TestCategory("unit")]
    public void StatusCode_PropertyShouldExist()
    {
        //arrange
        CosmosItemResponse<object> subject = new TestCosmosItemResponse<object>(null, HttpStatusCode.OK);

        //act
        HttpStatusCode _ = subject.StatusCode;

        //assert
    }

    [TestMethod, TestCategory("unit")]
    public void StatusCode_PropertyShouldBeGetOnly()
    {
        //arrange
        PropertyInfo propertyInfo = typeof(CosmosItemResponse<object>).GetProperty("StatusCode");

        //act
        bool hasGetter = propertyInfo?.CanRead == true;
        bool hasSetter = propertyInfo?.CanWrite == true;

        //assert
        _ = hasGetter.Should().BeTrue("Value property should have a getter");
        _ = hasSetter.Should().BeFalse("Value property should not have a setter");
    }

    [TestMethod, TestCategory("unit")]
    public void StatusCode_ShouldBeAbstract()
    {
        //arrange
        PropertyInfo propertyInfo = typeof(CosmosItemResponse<object>).GetProperty("StatusCode");

        //act
        bool actual = propertyInfo!.GetMethod!.IsAbstract && propertyInfo.GetMethod.IsFinal is false;

        //assert
        _ = actual.Should().BeTrue("Value property should be abstract");
    }

    [TestMethod, TestCategory("unit")]
    public void IsSuccessfulStatusCode_ShouldExist()
    {
        //arrange
        CosmosItemResponse<object> subject = new TestCosmosItemResponse<object>(null, HttpStatusCode.OK);

        //act
        bool _ = subject.IsSuccessfulStatusCode();

        //assert
    }

    [TestMethod, TestCategory("unit")]
    public void IsSuccessfulStatusCode_ShouldReturnTrueFor200()
    {
        //arrange
        CosmosItemResponse<object> subject = new TestCosmosItemResponse<object>(null, HttpStatusCode.OK);

        //act
        bool actual = subject.IsSuccessfulStatusCode();

        //assert
        _ = actual.Should().BeTrue();
    }

    [TestMethod, TestCategory("unit")]
    public void IsSuccessfulStatusCode_ShouldReturnFalseFor199()
    {
        //arrange
        CosmosItemResponse<object> subject = new TestCosmosItemResponse<object>(null, (HttpStatusCode)199);

        //act
        bool actual = subject.IsSuccessfulStatusCode();

        //assert
        _ = actual.Should().BeFalse();
    }

    private sealed class TestCosmosItemResponse<T> : CosmosItemResponse<T>
    {
        public TestCosmosItemResponse(T origin, HttpStatusCode status)
        {
            StatusCode = status;
            Value = origin;
        }

        public override T Value { get; }
        public override HttpStatusCode StatusCode { get; }

        public override T AsSystemType() => throw new System.NotImplementedException();
    }
}
