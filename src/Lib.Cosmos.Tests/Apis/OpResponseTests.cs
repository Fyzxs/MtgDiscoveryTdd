using System.Net;
using System.Reflection;
using Lib.Cosmos.Apis;
using Lib.Cosmos.OpResponses;
using Lib.Cosmos.Tests.Fakes;
using TestConvenience.Universal.Tests;

namespace Lib.Cosmos.Tests.Apis;

[TestClass]
public sealed class OpResponseTests : BaseToSystemTypeTests<OpResponse<object>, object>
{
    [TestMethod, TestCategory("unit")]
    public void Value_PropertyShouldExist()
    {
        //arrange
        OpResponse<object> subject = new TestOpResponse<object>(null, HttpStatusCode.OK);

        //act
        object _ = subject.Value;

        //assert
    }

    [TestMethod, TestCategory("unit")]
    public void Value_PropertyShouldBeGetOnly()
    {
        //arrange
        PropertyInfo propertyInfo = typeof(OpResponse<object>).GetProperty("Value");

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
        PropertyInfo propertyInfo = typeof(OpResponse<object>).GetProperty("Value");

        //act
        bool actual = propertyInfo!.GetMethod!.IsAbstract && propertyInfo.GetMethod.IsFinal is false;

        //assert
        _ = actual.Should().BeTrue("Value property should be abstract");
    }

    [TestMethod, TestCategory("unit")]
    public void StatusCode_PropertyShouldExist()
    {
        //arrange
        OpResponse<object> subject = new TestOpResponse<object>(null, HttpStatusCode.OK);

        //act
        HttpStatusCode _ = subject.StatusCode;

        //assert
    }

    [TestMethod, TestCategory("unit")]
    public void StatusCode_PropertyShouldBeGetOnly()
    {
        //arrange
        PropertyInfo propertyInfo = typeof(OpResponse<object>).GetProperty("StatusCode");

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
        PropertyInfo propertyInfo = typeof(OpResponse<object>).GetProperty("StatusCode");

        //act
        bool actual = propertyInfo!.GetMethod!.IsAbstract && propertyInfo.GetMethod.IsFinal is false;

        //assert
        _ = actual.Should().BeTrue("Value property should be abstract");
    }

    [TestMethod, TestCategory("unit")]
    public void IsSuccessfulStatusCode_ShouldExist()
    {
        //arrange
        OpResponse<object> subject = new TestOpResponse<object>(null, HttpStatusCode.OK);

        //act
        bool _ = subject.IsSuccessfulStatusCode();

        //assert
    }

    [TestMethod, TestCategory("unit")]
    public void IsSuccessfulStatusCode_ShouldReturnTrueFor200()
    {
        //arrange
        OpResponse<object> subject = new TestOpResponse<object>(null, HttpStatusCode.OK);

        //act
        bool actual = subject.IsSuccessfulStatusCode();

        //assert
        _ = actual.Should().BeTrue();
    }

    [TestMethod, TestCategory("unit")]
    public void IsSuccessfulStatusCode_ShouldReturnTrueFor299()
    {
        //arrange
        OpResponse<object> subject = new TestOpResponse<object>(null, (HttpStatusCode)299);

        //act
        bool actual = subject.IsSuccessfulStatusCode();

        //assert
        _ = actual.Should().BeTrue();
    }

    [TestMethod, TestCategory("unit")]
    public void IsSuccessfulStatusCode_ShouldReturnFalseFor199()
    {
        //arrange
        OpResponse<object> subject = new TestOpResponse<object>(null, (HttpStatusCode)199);

        //act
        bool actual = subject.IsSuccessfulStatusCode();

        //assert
        _ = actual.Should().BeFalse();
    }

    [TestMethod, TestCategory("unit")]
    public void IsSuccessfulStatusCode_ShouldReturnFalseFor300()
    {
        //arrange
        OpResponse<object> subject = new TestOpResponse<object>(null, (HttpStatusCode)300);

        //act
        bool actual = subject.IsSuccessfulStatusCode();

        //assert
        _ = actual.Should().BeFalse();
    }

    [TestMethod, TestCategory("unit")]
    public void IsSuccessfulStatusCode_ShouldReturnFalseFor500()
    {
        //arrange
        OpResponse<object> subject = new TestOpResponse<object>(null, (HttpStatusCode)500);

        //act
        bool actual = subject.IsSuccessfulStatusCode();

        //assert
        _ = actual.Should().BeFalse();
    }

    [TestMethod, TestCategory("unit")]
    public void IsNotSuccessfulStatusCode_ShouldReturnTrueWhenSuccessIsFalse()
    {
        //arrange
        OpResponse<object> subject = new TestOpResponse<object>(null, (HttpStatusCode)500);

        //act
        bool actual = subject.IsNotSuccessfulStatusCode();

        //assert
        _ = actual.Should().BeTrue();
    }

    [TestMethod, TestCategory("unit")]
    public void IsNotSuccessfulStatusCode_ShouldReturnFalseWhenSuccessIsTrue()
    {
        //arrange
        OpResponse<object> subject = new TestOpResponse<object>(null, (HttpStatusCode)200);

        //act
        bool actual = subject.IsNotSuccessfulStatusCode();

        //assert
        _ = actual.Should().BeFalse();
    }

    [TestMethod, TestCategory("unit")]
    public void CosmosItemResponse_ShouldImplementAsSystemType()
    {
        //arrange
        MethodInfo methodInfo = typeof(OpResponse<object>).GetMethod("AsSystemType");

        //act
        bool isOverride = methodInfo?.DeclaringType == typeof(OpResponse<object>);

        //assert
        _ = isOverride.Should().BeTrue("CosmosItemResponse should implement the AsSystemType method from its superclass");
    }

    [TestMethod, TestCategory("unit")]
    public void AsSystemType_ShouldReturnValue()
    {
        //arrange
        object obj = new();
        OpResponse<object> subject = new TestOpResponse<object>(obj, HttpStatusCode.OK);

        //act
        object actual = subject.AsSystemType();

        //assert
        _ = actual.Should().BeSameAs(obj);
    }

    private sealed class TestOpResponse<T> : OpResponse<T>
    {
        public TestOpResponse(T origin, HttpStatusCode status)
        {
            StatusCode = status;
            Value = origin;
        }

        public override T Value { get; }
        public override HttpStatusCode StatusCode { get; }
    }
}

[TestClass]
public sealed class ItemOpResponseTests
{
    [TestMethod, TestCategory("unit")]
    public void Should_Exist()
    {
        //arrange

        //act
        _ = new ItemOpResponse<object>(new ItemResponseFake());

        //assert
    }
}
