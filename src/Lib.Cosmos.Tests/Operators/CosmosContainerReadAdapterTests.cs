using System;
using System.Net;
using System.Threading.Tasks;
using Lib.Cosmos.Apis;
using Lib.Cosmos.Apis.Operators;
using Lib.Cosmos.Apis.Operators.Items;
using Lib.Cosmos.Apis.Operators.Responses;
using Lib.Cosmos.Apis.Primitives;
using Lib.Cosmos.Operators;
using Lib.Cosmos.Tests.Fakes;

namespace Lib.Cosmos.Tests.Operators;

[TestClass]
public sealed class CosmosContainerReadItemOperatorTests
{
    [TestMethod, TestCategory("unit")]
    public void Should_Exist()
    {
        //arrange

        //act
        LoggerFake loggerFake = new();
        ICosmosContainerReadItemOperator _ = new CosmosContainerReadItemOperator(loggerFake);

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
        CosmosContainerReadItemOperator subject = new(loggerFake);

        //act
        OpResponse<CosmosItem> actual = await subject.ReadItemAsync<CosmosItem>(
            containerFake, new ReadPointItem()
            {
                Id = new StringCosmosItemId("ignored"),
                Partition = new StringPartitionKeyValue("also_ignored")
            }).ConfigureAwait(false);

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
        CosmosContainerReadItemOperator subject = new(loggerFake);

        //act
        _ = subject.ReadItemAsync<CosmosItem>(containerFake, new ReadPointItem
        {
            Id = new StringCosmosItemId("ignored"),
            Partition = new StringPartitionKeyValue("also_ignored")
        });

        //assert
        _ = loggerFake.Logs.ToString().Should().Contain("ReadItem cost: [RequestCharge=1234.56] [ElapsedTime=12:34:56]");
    }
}
