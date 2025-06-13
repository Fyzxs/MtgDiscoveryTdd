using Lib.Cosmos.Adapters;
using Lib.Cosmos.Apis.Adapters;
using Lib.Cosmos.Tests.Fakes;
using Microsoft.Azure.Cosmos;

namespace Lib.Cosmos.Tests.Adapters;

[TestClass]
public sealed class CosmosClientAdapterTests
{
    [TestMethod, TestCategory("unit")]
    public void Should_Exist()
    {
        //arrange
        using CosmosClient cosmosClient = new("https://localhost:8081", "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==");

        //act
        ICosmosClientAdapter _ = new CosmosClientAdapter(cosmosClient);

        //assert
    }

    [TestMethod, TestCategory("unit")]
    public void GetContainer_ShouldReturnContainer()
    {
        //arrange
        using CosmosClient cosmosClient = new("https://localhost:8081", "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==");
        CosmosClientAdapter subject = new(cosmosClient);
        CosmosAccountNameFake accountNameFake = new("test-account");
        CosmosDatabaseNameFake databaseNameFake = new("test-db");
        CosmosCollectionNameFake collectionNameFake = new("test-collection");

        //act
        Container actual = subject.GetContainer(accountNameFake, databaseNameFake, collectionNameFake);

        //assert
        _ = actual.Should().NotBeNull();
    }
}