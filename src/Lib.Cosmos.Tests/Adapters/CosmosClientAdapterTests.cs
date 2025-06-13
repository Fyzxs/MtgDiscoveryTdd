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
        LoggerFake loggerFake = new();

        //act
        ICosmosClientAdapter _ = new CosmosClientAdapter(cosmosClient, loggerFake);

        //assert
    }

    [TestMethod, TestCategory("unit")]
    public void GetContainer_ShouldReturnContainer()
    {
        //arrange
        using CosmosClient cosmosClient = new("https://localhost:8081", "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==");
        LoggerFake loggerFake = new();
        CosmosClientAdapter subject = new(cosmosClient, loggerFake);
        CosmosAccountNameFake accountNameFake = new("test-account");
        CosmosDatabaseNameFake databaseNameFake = new("test-db");
        CosmosCollectionNameFake collectionNameFake = new("test-collection");

        //act
        Container actual = subject.GetContainer(accountNameFake, databaseNameFake, collectionNameFake);

        //assert
        _ = actual.Should().NotBeNull();
    }

    [TestMethod, TestCategory("unit")]
    public void GetContainer_ShouldLogInformation()
    {
        //arrange
        using CosmosClient cosmosClient = new("https://localhost:8081", "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==");
        LoggerFake loggerFake = new();
        CosmosClientAdapter subject = new(cosmosClient, loggerFake);
        CosmosAccountNameFake accountNameFake = new("test-account");
        CosmosDatabaseNameFake databaseNameFake = new("test-db");
        CosmosCollectionNameFake collectionNameFake = new("test-collection");

        //act
        _ = subject.GetContainer(accountNameFake, databaseNameFake, collectionNameFake);

        //assert
        string logs = loggerFake.Logs.ToString();
        _ = logs.Should().Contain("Getting container: [AccountName=test-account] [DatabaseName=test-db] [CollectionName=test-collection]");
    }
}