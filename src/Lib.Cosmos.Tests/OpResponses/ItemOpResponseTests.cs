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
}