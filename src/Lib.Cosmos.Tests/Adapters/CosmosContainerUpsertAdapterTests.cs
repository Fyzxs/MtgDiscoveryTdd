using System.Net;
using System.Threading.Tasks;
using Lib.Cosmos.Adapters;
using Lib.Cosmos.Apis;
using Lib.Cosmos.Tests.Fakes;

namespace Lib.Cosmos.Tests.Adapters;

[TestClass]
public sealed class CosmosContainerUpsertAdapterTests
{
    [TestMethod, TestCategory("unit")]
    public void Should_Exist()
    {
        //arrange

        //act
        ICosmosContainerUpsertAdapter _ = new CosmosContainerUpsertAdapter();

        //assert
    }

    [TestMethod, TestCategory("unit")]
    public async Task UpsertItemAsync_ShouldCallUpsertItemAsyncOnContainer()
    {
        //arrange
        CosmosItem cosmosItem = new();
        ItemResponseFake<CosmosItem> upsertItemAsyncResponse = new()
        {
            ResourceResult = cosmosItem,
            StatusCodeResult = HttpStatusCode.MethodNotAllowed
        };
        ContainerFake<CosmosItem> containerFake = new()
        {
            UpsertItemAsyncResponse = upsertItemAsyncResponse
        };
        CosmosContainerUpsertAdapter subject = new();

        //act
        OpResponse<CosmosItem> actual = await subject.UpsertItemAsync<CosmosItem>(containerFake, cosmosItem).ConfigureAwait(false);

        //assert
        _ = actual.Value.Should().BeSameAs(cosmosItem);
    }
}
