using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions.Primitives;
using Lib.Cosmos.Adapters;
using Lib.Cosmos.Apis;
using Lib.Cosmos.Apis.Adapters;
using Lib.Cosmos.Apis.Queries;
using Lib.Cosmos.Tests.Fakes;

namespace Lib.Cosmos.Tests.Adapters;

[TestClass]
public sealed class CosmosContainerQueryAdapterTests
{
    [TestMethod, TestCategory("unit")]
    public void Should_Exist()
    {
        //arrange

        //act
        LoggerFake loggerFake = new();
        ICosmosContainerQueryAdapter _ = new CosmosContainerQueryAdapter(loggerFake);

        //assert
    }

    [TestMethod]
    public async Task QueryAsync_ShouldCallGetItemQueryIteratorOnContainerAsync()
    {
        //arrange
        LoggerFake loggerFake = new();
        CosmosContainerQueryAdapter subject = new(loggerFake);
        FeedIteratorFake<CosmosItem> feedIteratorFake = new()
        {
            ReadNextAsyncResponse = new FeedResponseFake<CosmosItem>([new CosmosItem(), new CosmosItem(), new CosmosItem()])
            {
                RequestChargeResult = 1234.56,
                DiagnosticsResult = new CosmosDiagnosticsFake()
                {
                    GetClientElapsedTimeResult = new TimeSpan(0, 12, 34, 56)
                }
            }
        };
        ContainerFake<CosmosItem> containerFake = new()
        {
            GetItemQueryIteratorResponse = feedIteratorFake
        };
        QueryDefinitionFake queryDefinitionFake = new();
        StringPartitionKeyValue partitionKeyValue = new("sample");

        //act
        IEnumerable<CosmosItem> _ = await subject.QueryAsync<CosmosItem>(containerFake, queryDefinitionFake, partitionKeyValue).ConfigureAwait(false);

        //assert
        containerFake.GetItemQueryIteratorInvokeCount.Should().Be(1);
    }

    [TestMethod]
    public async Task QueryAsync_ShouldReturnSizeOfSourceAsync()
    {
        //arrange
        LoggerFake loggerFake = new();
        FeedIteratorFake<CosmosItem> feedIteratorFake = new()
        {
            ReadNextAsyncResponse = new FeedResponseFake<CosmosItem>([new CosmosItem(), new CosmosItem(), new CosmosItem()])
            {
                RequestChargeResult = 1234.56,
                DiagnosticsResult = new CosmosDiagnosticsFake()
                {
                    GetClientElapsedTimeResult = new TimeSpan(0, 12, 34, 56)
                }
            }
        };
        CosmosContainerQueryAdapter subject = new(loggerFake);
        ContainerFake<CosmosItem> containerFake = new()
        {
            GetItemQueryIteratorResponse = feedIteratorFake
        };
        QueryDefinitionFake queryDefinitionFake = new();
        StringPartitionKeyValue partitionKeyValue = new("sample");

        //act
        IEnumerable<CosmosItem> actual = await subject.QueryAsync<CosmosItem>(containerFake, queryDefinitionFake, partitionKeyValue).ConfigureAwait(false);

        //assert
        containerFake.GetItemQueryIteratorInvokeCount.Should().Be(1);
        List<CosmosItem> actualList = actual.ToList();
        actualList.Count.Should().Be(3);
    }

    [TestMethod, TestCategory("unit")]
    public async Task UpsertItemAsync_ShouldLogExpected()
    {
        //arrange
        LoggerFake loggerFake = new();
        FeedIteratorFake<CosmosItem> feedIteratorFake = new()
        {
            ReadNextAsyncResponse = new FeedResponseFake<CosmosItem>([new CosmosItem(), new CosmosItem(), new CosmosItem()])
            {
                RequestChargeResult = 1234.56,
                DiagnosticsResult = new CosmosDiagnosticsFake()
                {
                    GetClientElapsedTimeResult = new TimeSpan(0, 12, 34, 56)
                }
            }
        };
        CosmosContainerQueryAdapter subject = new(loggerFake);
        ContainerFake<CosmosItem> containerFake = new()
        {
            GetItemQueryIteratorResponse = feedIteratorFake
        };
        QueryDefinitionFake queryDefinitionFake = new();
        StringPartitionKeyValue partitionKeyValue = new("sample");

        //act
        IEnumerable<CosmosItem> _ = await subject.QueryAsync<CosmosItem>(containerFake, queryDefinitionFake, partitionKeyValue).ConfigureAwait(false);

        //assert
        AndConstraint<StringAssertions> __ = loggerFake.Logs.ToString().Should().Contain("GetItemQueryIterator cost: [RequestCharge=1234.56] [ElapsedTime=12:34:56]");
    }
}
