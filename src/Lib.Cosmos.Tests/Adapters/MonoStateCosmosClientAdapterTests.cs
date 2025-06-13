using Lib.Cosmos.Adapters;
using Lib.Cosmos.Apis.Adapters;
using Lib.Cosmos.Apis.Ids;
using Lib.Cosmos.Tests.Fakes;
using Microsoft.Azure.Cosmos;

namespace Lib.Cosmos.Tests.Adapters;

internal sealed class TestCosmosClientAdapterFactory : ICosmosClientAdapterFactory
{
    private readonly ICosmosClientAdapter _adapter1;
    private readonly ICosmosClientAdapter _adapter2;
    private int _callCount;

    public TestCosmosClientAdapterFactory(ICosmosClientAdapter adapter1, ICosmosClientAdapter adapter2)
    {
        _adapter1 = adapter1;
        _adapter2 = adapter2;
    }

    public int InstanceInvokeCount => _callCount;

    public ICosmosClientAdapter Instance(CosmosAccountName accountName)
    {
        _callCount++;
        return _callCount == 1 ? _adapter1 : _adapter2;
    }
}

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
        CosmosAccountNameFake accountNameFake = new("test-account-1");
        CosmosDatabaseNameFake databaseNameFake = new("test-db");
        CosmosCollectionNameFake collectionNameFake = new("test-collection");

        //act
        Container actual = subject.GetContainer(accountNameFake, databaseNameFake, collectionNameFake);

        //assert
        _ = factoryFake.InstanceInvokeCount.Should().Be(1);
        _ = actual.Should().BeSameAs(containerFake);
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
        CosmosAccountNameFake accountNameFake = new("test-account-3");
        CosmosDatabaseNameFake databaseNameFake = new("test-db");
        CosmosCollectionNameFake collectionNameFake = new("test-collection");
        Container firstResult = subject.GetContainer(accountNameFake, databaseNameFake, collectionNameFake);

        //act
        Container secondResult = subject.GetContainer(accountNameFake, databaseNameFake, collectionNameFake);

        //assert
        _ = factoryFake.InstanceInvokeCount.Should().Be(1);
        _ = firstResult.Should().BeSameAs(containerFake);
        _ = secondResult.Should().BeSameAs(containerFake);
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
        _ = firstResult.Should().BeSameAs(containerFake);
        _ = secondResult.Should().BeSameAs(containerFake);
    }

    [TestMethod, TestCategory("unit")]
    public void GetContainer_ShouldShareStateBetweenInstances()
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
        MonoStateCosmosClientAdapter subject1 = new(factoryFake);
        MonoStateCosmosClientAdapter subject2 = new(factoryFake);
        CosmosAccountNameFake accountNameFake = new("test-account-5");
        CosmosDatabaseNameFake databaseNameFake = new("test-db");
        CosmosCollectionNameFake collectionNameFake = new("test-collection");
        Container firstResult = subject1.GetContainer(accountNameFake, databaseNameFake, collectionNameFake);

        //act
        Container secondResult = subject2.GetContainer(accountNameFake, databaseNameFake, collectionNameFake);

        //assert
        _ = factoryFake.InstanceInvokeCount.Should().Be(1);
        _ = clientAdapterFake.GetContainerInvokeCount.Should().Be(2);
        _ = firstResult.Should().BeSameAs(containerFake);
        _ = secondResult.Should().BeSameAs(containerFake);
    }

    [TestMethod, TestCategory("unit")]
    public void GetContainer_ShouldCreateSeparateAdaptersForDifferentAccounts()
    {
        //arrange
        ContainerFake<object> containerFake1 = new();
        ContainerFake<object> containerFake2 = new();
        CosmosClientAdapterFake clientAdapterFake1 = new()
        {
            GetContainerResponse = containerFake1
        };
        CosmosClientAdapterFake clientAdapterFake2 = new()
        {
            GetContainerResponse = containerFake2
        };

        TestCosmosClientAdapterFactory factoryFake = new(clientAdapterFake1, clientAdapterFake2);
        MonoStateCosmosClientAdapter subject = new(factoryFake);
        CosmosAccountNameFake accountNameFake1 = new("test-account-6a");
        CosmosAccountNameFake accountNameFake2 = new("test-account-6b");
        CosmosDatabaseNameFake databaseNameFake = new("test-db");
        CosmosCollectionNameFake collectionNameFake = new("test-collection");

        //act
        Container result1 = subject.GetContainer(accountNameFake1, databaseNameFake, collectionNameFake);
        Container result2 = subject.GetContainer(accountNameFake2, databaseNameFake, collectionNameFake);

        //assert
        _ = factoryFake.InstanceInvokeCount.Should().Be(2);
        _ = clientAdapterFake1.GetContainerInvokeCount.Should().Be(1);
        _ = clientAdapterFake2.GetContainerInvokeCount.Should().Be(1);
        _ = result1.Should().NotBeSameAs(result2);
        _ = result1.Should().BeSameAs(containerFake1);
        _ = result2.Should().BeSameAs(containerFake2);
    }
}
