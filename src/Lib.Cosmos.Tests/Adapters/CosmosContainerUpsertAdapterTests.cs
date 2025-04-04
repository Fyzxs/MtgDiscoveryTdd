using System.Threading.Tasks;
using Lib.Cosmos.Adapters;
using Lib.Cosmos.Tests.Fakes;
using Microsoft.Azure.Cosmos;

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
        ItemResponseFake<CosmosItem> upsertItemAsyncResponse = new();
        ContainerFake<CosmosItem> containerFake = new()
        {
            UpsertItemAsyncResponse = upsertItemAsyncResponse
        };
        CosmosItem cosmosItem = new();
        CosmosContainerUpsertAdapter subject = new();

        //act
        ItemResponse<CosmosItem> actual = await subject.UpsertItemAsync<CosmosItem>(containerFake, cosmosItem).ConfigureAwait(false);

        //assert
        _ = actual.Should().BeSameAs(upsertItemAsyncResponse);
    }
}
