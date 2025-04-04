using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Lib.Cosmos.Adapters;
using Lib.Cosmos.Apis;
using Lib.Cosmos.Tests.Fakes;
using Microsoft.Testing.Platform.Logging;

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

    [TestMethod, TestCategory("unit")]
    public async Task UpsertItemAsync_ShouldLogExpected()
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

public sealed class LoggerFake : ILogger
{
    public StringBuilder Logs { get; set; }

    public async Task LogAsync<TState>(LogLevel logLevel, TState state, Exception exception,
        Func<TState, Exception, string> formatter)
    {
        await Task.Delay(0).ConfigureAwait(false);
        Log(logLevel, state, exception, formatter);
    }

    public void Log<TState>(LogLevel logLevel, TState state, Exception exception, Func<TState, Exception, string> formatter) => Logs.AppendLine(formatter(state, exception));

    public bool IsEnabled(LogLevel logLevel) => true;
}
