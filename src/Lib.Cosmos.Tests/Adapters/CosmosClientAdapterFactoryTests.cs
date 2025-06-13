using System;
using Lib.Cosmos.Adapters;
using Lib.Cosmos.Apis.Adapters;
using Lib.Cosmos.Tests.Fakes;

namespace Lib.Cosmos.Tests.Adapters;

[TestClass]
public sealed class CosmosClientAdapterFactoryTests
{
    private const string TestCosmosKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";

    [TestInitialize]
    public void Setup()
    {
        Environment.SetEnvironmentVariable("COSMOS_DB_KEY", TestCosmosKey);
    }

    [TestCleanup]
    public void Cleanup()
    {
        Environment.SetEnvironmentVariable("COSMOS_DB_KEY", null);
    }
    [TestMethod, TestCategory("unit")]
    public void Should_Exist()
    {
        //arrange
        using LoggerFactoryFake loggerFactoryFake = new();

        //act
        ICosmosClientAdapterFactory _ = new CosmosClientAdapterFactory(loggerFactoryFake);

        //assert
    }

    [TestMethod, TestCategory("unit")]
    public void Instance_ShouldReturnICosmosClientAdapter()
    {
        //arrange
        using LoggerFactoryFake loggerFactoryFake = new();
        CosmosClientAdapterFactory subject = new(loggerFactoryFake);
        CosmosAccountNameFake accountNameFake = new("test-account");

        //act
        ICosmosClientAdapter actual = subject.Instance(accountNameFake);

        //assert
        _ = actual.Should().NotBeNull();
        _ = actual.Should().BeOfType<CosmosClientAdapter>();
    }

    [TestMethod, TestCategory("unit")]
    public void Instance_ShouldReturnDifferentInstancesForDifferentCalls()
    {
        //arrange
        using LoggerFactoryFake loggerFactoryFake = new();
        CosmosClientAdapterFactory subject = new(loggerFactoryFake);
        CosmosAccountNameFake accountNameFake = new("test-account");

        //act
        ICosmosClientAdapter actual1 = subject.Instance(accountNameFake);
        ICosmosClientAdapter actual2 = subject.Instance(accountNameFake);

        //assert
        _ = actual1.Should().NotBeSameAs(actual2);
    }

    [TestMethod, TestCategory("unit")]
    public void Instance_ShouldThrowWhenEnvironmentVariableNotSet()
    {
        //arrange
        Environment.SetEnvironmentVariable("COSMOS_DB_KEY", null);
        using LoggerFactoryFake loggerFactoryFake = new();
        CosmosClientAdapterFactory subject = new(loggerFactoryFake);
        CosmosAccountNameFake accountNameFake = new("test-account");

        //act
        Action act = () => subject.Instance(accountNameFake);

        //assert
        _ = act.Should().Throw<InvalidOperationException>()
            .WithMessage("COSMOS_DB_KEY environment variable is required but not set.");
    }

    [TestMethod, TestCategory("unit")]
    public void Instance_ShouldLogInformationWhenCreatingInstance()
    {
        //arrange
        using LoggerFactoryFake loggerFactoryFake = new();
        LoggerFake factoryLogger = new();

        // We need to modify the factory fake to return our specific logger for testing
        using LoggerFactoryTestHelper loggerFactoryTestHelper = new(factoryLogger);
        CosmosClientAdapterFactory subject = new(loggerFactoryTestHelper);
        CosmosAccountNameFake accountNameFake = new("test-account");

        //act
        _ = subject.Instance(accountNameFake);

        //assert
        string logs = factoryLogger.Logs.ToString();
        _ = logs.Should().Contain("Creating CosmosClientAdapter instance for account: [AccountName=test-account]");
    }
}