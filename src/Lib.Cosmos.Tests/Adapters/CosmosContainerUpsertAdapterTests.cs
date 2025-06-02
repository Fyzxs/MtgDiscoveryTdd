using System;
using System.Net;
using System.Threading.Tasks;
using Lib.Cosmos.Adapters;
using Lib.Cosmos.Apis;
using Lib.Cosmos.Apis.Adapters;
using Lib.Cosmos.Apis.OpResponses;
using Lib.Cosmos.Tests.Fakes;
using Microsoft.Extensions.Logging;

namespace Lib.Cosmos.Tests.Adapters;

[TestClass]
public sealed class CosmosContainerUpsertAdapterTests
{
    [TestMethod, TestCategory("unit")]
    public void Should_Exist()
    {
        //arrange

        //act
        LoggerFake loggerFake = new();
        ICosmosContainerUpsertAdapter _ = new CosmosContainerUpsertAdapter(loggerFake);

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
            StatusCodeResult = HttpStatusCode.MethodNotAllowed,
            RequestChargeResult = 1234.56,
            DiagnosticsResult = new CosmosDiagnosticsFake()
            {
                GetClientElapsedTimeResult = new TimeSpan(0, 12, 34, 56)
            }
        };
        ContainerFake<CosmosItem> containerFake = new()
        {
            UpsertItemAsyncResponse = upsertItemAsyncResponse
        };
        LoggerFake loggerFake = new();
        CosmosContainerUpsertAdapter subject = new(loggerFake);

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
            StatusCodeResult = HttpStatusCode.MethodNotAllowed,
            RequestChargeResult = 1234.56,
            DiagnosticsResult = new CosmosDiagnosticsFake()
            {
                GetClientElapsedTimeResult = new TimeSpan(0, 12, 34, 56)
            }
        };
        ContainerFake<CosmosItem> containerFake = new()
        {
            UpsertItemAsyncResponse = upsertItemAsyncResponse
        };
        LoggerFake loggerFake = new();
        CosmosContainerUpsertAdapter subject = new(loggerFake);

        //act
        _ = await subject.UpsertItemAsync<CosmosItem>(containerFake, cosmosItem).ConfigureAwait(false);

        //assert
        _ = loggerFake.Logs.ToString().Should().Contain("UpsertItem cost: [RequestCharge=1234.56] [ElapsedTime=12:34:56]");
    }
}
