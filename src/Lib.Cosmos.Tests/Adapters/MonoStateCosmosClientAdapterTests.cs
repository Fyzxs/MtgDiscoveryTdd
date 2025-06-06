using Lib.Cosmos.Adapters;
using Lib.Cosmos.Apis.Adapters;
using Lib.Cosmos.Tests.Fakes;
using Microsoft.Azure.Cosmos;

namespace Lib.Cosmos.Tests.Adapters;

[TestClass]
public sealed class MonoStateCosmosClientAdapterTests
{
    [TestMethod, TestCategory("unit")]
    public void Should_Exist()
    {
        //arrange

        //act
        CosmosClientAdapterFactoryFake factoryFake = new();
        ICosmosClientAdapter _ = new MonoStateCosmosClientAdapter(factoryFake);

        //assert
    }

    [TestMethod, TestCategory("unit")]
    public void GetContainer_ShouldCallFactoryInstance_WhenFirstCall()
    {
        //arrange
        CosmosClientAdapterFake clientAdapterFake = new();
        CosmosClientAdapterFactoryFake factoryFake = new()
        {
            InstanceResponse = clientAdapterFake
        };
        MonoStateCosmosClientAdapter subject = new(factoryFake);
        CosmosDatabaseNameFake databaseNameFake = new("test-db");
        CosmosCollectionNameFake collectionNameFake = new("test-collection");

        //act
        _ = subject.GetContainer(databaseNameFake, collectionNameFake);

        //assert
        _ = factoryFake.InstanceInvokeCount.Should().Be(1);
    }

    [TestMethod, TestCategory("unit")]
    public void GetContainer_ShouldCallGetContainerOnAdapter()
    {
        //arrange
        Container expectedContainer = null;
        CosmosClientAdapterFake clientAdapterFake = new()
        {
            GetContainerResponse = expectedContainer
        };
        CosmosClientAdapterFactoryFake factoryFake = new()
        {
            InstanceResponse = clientAdapterFake
        };
        MonoStateCosmosClientAdapter subject = new(factoryFake);
        CosmosDatabaseNameFake databaseNameFake = new("test-db");
        CosmosCollectionNameFake collectionNameFake = new("test-collection");

        //act
        Container actual = subject.GetContainer(databaseNameFake, collectionNameFake);

        //assert
        _ = clientAdapterFake.GetContainerInvokeCount.Should().Be(1);
        _ = actual.Should().BeSameAs(expectedContainer);
    }

    [TestMethod, TestCategory("unit")]
    public void GetContainer_ShouldNotCallFactoryInstance_WhenSecondCall()
    {
        //arrange
        CosmosClientAdapterFake clientAdapterFake = new();
        CosmosClientAdapterFactoryFake factoryFake = new()
        {
            InstanceResponse = clientAdapterFake
        };
        MonoStateCosmosClientAdapter subject = new(factoryFake);
        CosmosDatabaseNameFake databaseNameFake = new("test-db");
        CosmosCollectionNameFake collectionNameFake = new("test-collection");
        _ = subject.GetContainer(databaseNameFake, collectionNameFake);

        //act
        _ = subject.GetContainer(databaseNameFake, collectionNameFake);

        //assert
        _ = factoryFake.InstanceInvokeCount.Should().Be(1);
    }

    [TestMethod, TestCategory("unit")]
    public void GetContainer_ShouldUseSameInstanceForMultipleCalls()
    {
        //arrange
        Container expectedContainer = null;
        CosmosClientAdapterFake clientAdapterFake = new()
        {
            GetContainerResponse = expectedContainer
        };
        CosmosClientAdapterFactoryFake factoryFake = new()
        {
            InstanceResponse = clientAdapterFake
        };
        MonoStateCosmosClientAdapter subject = new(factoryFake);
        CosmosDatabaseNameFake databaseNameFake = new("test-db");
        CosmosCollectionNameFake collectionNameFake = new("test-collection");
        Container firstResult = subject.GetContainer(databaseNameFake, collectionNameFake);

        //act
        Container secondResult = subject.GetContainer(databaseNameFake, collectionNameFake);

        //assert
        _ = clientAdapterFake.GetContainerInvokeCount.Should().Be(2);
        _ = firstResult.Should().BeSameAs(secondResult);
    }

    [TestMethod, TestCategory("unit")]
    public void GetContainer_ShouldShareStateBetweenInstances()
    {
        //arrange
        CosmosClientAdapterFake clientAdapterFake = new();
        CosmosClientAdapterFactoryFake factoryFake = new()
        {
            InstanceResponse = clientAdapterFake
        };
        MonoStateCosmosClientAdapter subject1 = new(factoryFake);
        MonoStateCosmosClientAdapter subject2 = new(factoryFake);
        CosmosDatabaseNameFake databaseNameFake = new("test-db");
        CosmosCollectionNameFake collectionNameFake = new("test-collection");
        _ = subject1.GetContainer(databaseNameFake, collectionNameFake);

        //act
        _ = subject2.GetContainer(databaseNameFake, collectionNameFake);

        //assert
        _ = factoryFake.InstanceInvokeCount.Should().Be(1);
        _ = clientAdapterFake.GetContainerInvokeCount.Should().Be(2);
    }
}
