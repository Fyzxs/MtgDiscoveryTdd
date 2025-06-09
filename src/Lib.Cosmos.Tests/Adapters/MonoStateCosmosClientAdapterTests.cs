using Lib.Cosmos.Adapters;
using Lib.Cosmos.Apis.Adapters;
using Lib.Cosmos.Tests.Fakes;
using Microsoft.Azure.Cosmos;

namespace Lib.Cosmos.Tests.Adapters;

[TestClass, DoNotParallelize]
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
        CosmosAccountNameFake accountNameFake = new("test-account-1");
        CosmosDatabaseNameFake databaseNameFake = new("test-db");
        CosmosCollectionNameFake collectionNameFake = new("test-collection");

        //act
        _ = subject.GetContainer(accountNameFake, databaseNameFake, collectionNameFake);

        //assert
        _ = factoryFake.InstanceInvokeCount.Should().Be(1);
    }

    [TestMethod, TestCategory("unit")]
    public void GetContainer_ShouldCallGetContainerOnAdapter()
    {
        //arrange
        ContainerFake<object> containerFake = new();
        CosmosClientAdapterFake clientAdapterFake = new()
        {
            GetContainerResponse = containerFake
        };
        CosmosClientAdapterFactoryFake factoryFake = new()
        {
            InstanceResponse = clientAdapterFake
        };
        MonoStateCosmosClientAdapter subject = new(factoryFake);
        CosmosAccountNameFake accountNameFake = new("test-account-2");
        CosmosDatabaseNameFake databaseNameFake = new("test-db");
        CosmosCollectionNameFake collectionNameFake = new("test-collection");

        //act
        Container actual = subject.GetContainer(accountNameFake, databaseNameFake, collectionNameFake);

        //assert
        _ = clientAdapterFake.GetContainerInvokeCount.Should().Be(1);
        _ = actual.Should().BeSameAs(containerFake);
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
        CosmosAccountNameFake accountNameFake = new("test-account-3");
        CosmosDatabaseNameFake databaseNameFake = new("test-db");
        CosmosCollectionNameFake collectionNameFake = new("test-collection");
        _ = subject.GetContainer(accountNameFake, databaseNameFake, collectionNameFake);

        //act
        _ = subject.GetContainer(accountNameFake, databaseNameFake, collectionNameFake);

        //assert
        _ = factoryFake.InstanceInvokeCount.Should().Be(1);
    }

    [TestMethod, TestCategory("unit")]
    public void GetContainer_ShouldUseSameInstanceForMultipleCalls()
    {
        //arrange
        ContainerFake<object> containerFake = new();
        CosmosClientAdapterFake clientAdapterFake = new()
        {
            GetContainerResponse = containerFake
        };
        CosmosClientAdapterFactoryFake factoryFake = new()
        {
            InstanceResponse = clientAdapterFake
        };
        MonoStateCosmosClientAdapter subject = new(factoryFake);
        CosmosAccountNameFake accountNameFake = new("test-account-4");
        CosmosDatabaseNameFake databaseNameFake = new("test-db");
        CosmosCollectionNameFake collectionNameFake = new("test-collection");
        Container firstResult = subject.GetContainer(accountNameFake, databaseNameFake, collectionNameFake);

        //act
        Container secondResult = subject.GetContainer(accountNameFake, databaseNameFake, collectionNameFake);

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
        CosmosAccountNameFake accountNameFake = new("test-account-5");
        CosmosDatabaseNameFake databaseNameFake = new("test-db");
        CosmosCollectionNameFake collectionNameFake = new("test-collection");
        _ = subject1.GetContainer(accountNameFake, databaseNameFake, collectionNameFake);

        //act
        _ = subject2.GetContainer(accountNameFake, databaseNameFake, collectionNameFake);

        //assert
        _ = factoryFake.InstanceInvokeCount.Should().Be(1);
        _ = clientAdapterFake.GetContainerInvokeCount.Should().Be(2);
    }

    [TestMethod, TestCategory("unit")]
    public void GetContainer_ShouldCreateSeparateAdaptersForDifferentAccounts()
    {
        //arrange
        CosmosClientAdapterFake clientAdapterFake = new();
        CosmosClientAdapterFactoryFake factoryFake = new()
        {
            InstanceResponse = clientAdapterFake
        };
        MonoStateCosmosClientAdapter subject = new(factoryFake);
        CosmosAccountNameFake accountNameFake1 = new("test-account-6a");
        CosmosAccountNameFake accountNameFake2 = new("test-account-6b");
        CosmosDatabaseNameFake databaseNameFake = new("test-db");
        CosmosCollectionNameFake collectionNameFake = new("test-collection");

        //act
        _ = subject.GetContainer(accountNameFake1, databaseNameFake, collectionNameFake);
        _ = subject.GetContainer(accountNameFake2, databaseNameFake, collectionNameFake);

        //assert
        _ = factoryFake.InstanceInvokeCount.Should().Be(2);
        _ = clientAdapterFake.GetContainerInvokeCount.Should().Be(2);
    }
}
