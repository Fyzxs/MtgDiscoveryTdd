using System;
using System.Reflection;
using Lib.Cosmos.Apis;

namespace Lib.Cosmos.Tests.Apis;

[TestClass]
public sealed class CosmosContainerSpecTests
{
    [TestMethod, TestCategory("unit")]
    public void CosmosContainerSpec_ShouldExist()
    {
        //arrange

        //act
        CosmosContainerSpec _ = new();

        //assert
    }

    [TestMethod, TestCategory("unit")]
    public void DatabaseName_ShouldExist()
    {
        //arrange
        CosmosContainerSpec subject = new();

        //act
        string _ = subject.DatabaseName;

        //assert
    }

    [TestMethod, TestCategory("unit")]
    public void DatabaseName_ShouldBeWritable()
    {
        //arrange
        CosmosContainerSpec subject = new();
        string expected = "TestDatabase";

        //act
        subject.DatabaseName = expected;

        //assert
        _ = subject.DatabaseName.Should().Be(expected);
    }

    [TestMethod, TestCategory("unit")]
    public void ContainerName_ShouldExist()
    {
        //arrange
        CosmosContainerSpec subject = new();

        //act
        string _ = subject.ContainerName;

        //assert
    }

    [TestMethod, TestCategory("unit")]
    public void ContainerName_ShouldBeWritable()
    {
        //arrange
        CosmosContainerSpec subject = new();
        string expected = "TestContainer";

        //act
        subject.ContainerName = expected;

        //assert
        _ = subject.ContainerName.Should().Be(expected);
    }

    [TestMethod, TestCategory("unit")]
    public void PartitionKey_ShouldExist()
    {
        //arrange
        CosmosContainerSpec subject = new();

        //act
        string _ = subject.PartitionKey;

        //assert
    }

    [TestMethod, TestCategory("unit")]
    public void PartitionKey_ShouldBeWritable()
    {
        //arrange
        CosmosContainerSpec subject = new();
        string expected = "/testPartition";

        //act
        subject.PartitionKey = expected;

        //assert
        _ = subject.PartitionKey.Should().Be(expected);
    }

    [TestMethod, TestCategory("unit")]
    public void Throughput_ShouldExist()
    {
        //arrange
        CosmosContainerSpec subject = new();

        //act
        int? _ = subject.Throughput;

        //assert
    }

    [TestMethod, TestCategory("unit")]
    public void Throughput_ShouldBeWritable()
    {
        //arrange
        CosmosContainerSpec subject = new();
        int? expected = 400;

        //act
        subject.Throughput = expected;

        //assert
        _ = subject.Throughput.Should().Be(expected);
    }

    [TestMethod, TestCategory("unit")]
    public void Throughput_ShouldAllowNull()
    {
        //arrange
        CosmosContainerSpec subject = new();

        //act
        subject.Throughput = null;

        //assert
        _ = subject.Throughput.Should().BeNull();
    }
}