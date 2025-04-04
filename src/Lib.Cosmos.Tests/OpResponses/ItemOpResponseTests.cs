using System.Net;
using Lib.Cosmos.OpResponses;
using Lib.Cosmos.Tests.Fakes;

namespace Lib.Cosmos.Tests.OpResponses;

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

    [TestMethod, TestCategory("unit")]
    public void Value_ShouldReturnProvidedValue()
    {
        //arrange
        object resourceResult = new();
        ItemResponseFake itemResponseFake = new()
        {
            ResourceResult = resourceResult,
            StatusCodeResult = HttpStatusCode.MethodNotAllowed
        };
        ItemOpResponse<object> subject = new(itemResponseFake);

        //act
        object actual = subject.Value;

        //assert
        _ = actual.Should().BeSameAs(resourceResult);
    }

    [TestMethod, TestCategory("unit")]
    public void StatusCode_ShouldReturnProvidedCode()
    {
        //arrange
        object resourceResult = new();
        ItemResponseFake itemResponseFake = new()
        {
            ResourceResult = resourceResult,
            StatusCodeResult = HttpStatusCode.MethodNotAllowed
        };
        ItemOpResponse<object> subject = new(itemResponseFake);

        //act
        object actual = subject.StatusCode;

        //assert
        _ = actual.Should().Be(HttpStatusCode.MethodNotAllowed);
    }
}
