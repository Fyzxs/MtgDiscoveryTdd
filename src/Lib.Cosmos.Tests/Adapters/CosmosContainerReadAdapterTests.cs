using System;
using System.Net;
using System.Threading.Tasks;
using Lib.Cosmos.Adapters;
using Lib.Cosmos.Apis;
using Lib.Cosmos.Apis.Adapters;
using Lib.Cosmos.Apis.OpResponses;
using Lib.Cosmos.Tests.Fakes;

namespace Lib.Cosmos.Tests.Adapters;

[TestClass]
public sealed class CosmosContainerReadItemAdapterTests
{
    [TestMethod, TestCategory("unit")]
    public void Should_Exist()
    {
        //arrange

        //act
        LoggerFake loggerFake = new();
        ICosmosContainerReadItemAdapter _ = new CosmosContainerReadItemAdapter(loggerFake);

        //assert
    }

    [TestMethod, TestCategory("unit")]
    public async Task ReadItemAsync_ShouldCallReadItemAsyncOnContainerAsync()
    {
        //arrange
        CosmosItem cosmosItem = new();
        ItemResponseFake<CosmosItem> readItemAsyncResponse = new()
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
            ReadItemAsyncResponse = readItemAsyncResponse
        };
        LoggerFake loggerFake = new();
        CosmosContainerReadItemAdapter subject = new(loggerFake);

        //act
        OpResponse<CosmosItem> actual = await subject.ReadItemAsync<CosmosItem>(containerFake, new ReadPointItem()).ConfigureAwait(false);

        //assert
        _ = actual.Value.Should().BeSameAs(cosmosItem);
    }

    [TestMethod, TestCategory("unit")]
    public void ReadItemAsync_ShouldLogExpected()
    {
        //arrange
        CosmosItem cosmosItem = new();
        ItemResponseFake<CosmosItem> readItemAsyncResponse = new()
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
            ReadItemAsyncResponse = readItemAsyncResponse
        };
        LoggerFake loggerFake = new();
        CosmosContainerReadItemAdapter subject = new(loggerFake);

        //act
        _ = subject.ReadItemAsync<CosmosItem>(containerFake, new ReadPointItem());

        //assert
        _ = loggerFake.Logs.ToString().Should().Contain("ReadItem cost: [RequestCharge=1234.56] [ElapsedTime=12:34:56]");
    }
}
