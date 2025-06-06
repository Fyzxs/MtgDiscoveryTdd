using System.Reflection;
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
        CosmosDatabaseNameFake databaseName = new("test-db");
        CosmosCollectionNameFake collectionName = new("test-collection");

        //act
        _ = subject.GetContainer(databaseName, collectionName);

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
        CosmosDatabaseNameFake databaseName = new("test-db");
        CosmosCollectionNameFake collectionName = new("test-collection");

        //act
        Container actual = subject.GetContainer(databaseName, collectionName);

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
        CosmosDatabaseNameFake databaseName = new("test-db");
        CosmosCollectionNameFake collectionName = new("test-collection");

        //act
        _ = subject.GetContainer(databaseName, collectionName);
        _ = subject.GetContainer(databaseName, collectionName);

        //assert
        _ = factoryFake.InstanceInvokeCount.Should().Be(1);
    }

    [TestMethod, TestCategory("unit")]
    public void GetContainer_ShouldUseSameInstanceForMultipleCalls()
    {
        //arrange
        CosmosClientAdapterFake clientAdapterFake = new();
        CosmosClientAdapterFactoryFake factoryFake = new()
        {
            InstanceResponse = clientAdapterFake
        };
        MonoStateCosmosClientAdapter subject = new(factoryFake);
        CosmosDatabaseNameFake databaseName = new("test-db");
        CosmosCollectionNameFake collectionName = new("test-collection");

        //act
        _ = subject.GetContainer(databaseName, collectionName);
        _ = subject.GetContainer(databaseName, collectionName);

        //assert
        _ = clientAdapterFake.GetContainerInvokeCount.Should().Be(2);
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
        CosmosDatabaseNameFake databaseName = new("test-db");
        CosmosCollectionNameFake collectionName = new("test-collection");

        //act
        _ = subject1.GetContainer(databaseName, collectionName);
        _ = subject2.GetContainer(databaseName, collectionName);

        //assert
        _ = factoryFake.InstanceInvokeCount.Should().Be(1);
        _ = clientAdapterFake.GetContainerInvokeCount.Should().Be(2);
    }

    [TestCleanup]
    public void TestCleanup()
    {
        // Reset the static state for clean tests
        FieldInfo staticField = typeof(MonoStateCosmosClientAdapter).GetField("s_adapter", BindingFlags.NonPublic | BindingFlags.Static);
        staticField?.SetValue(null, null);
    }
}