using Lib.Cosmos.Apis.Queries;
using Microsoft.Azure.Cosmos;

namespace Lib.Cosmos.Tests.Apis.Queries;

[TestClass]
public sealed class StringPartitionKeyValueTests
{
    [TestMethod]
    public void ShouldExist()
    {
        //arrange
        PartitionKeyValue subject = new StringPartitionKeyValue("value");
        //act
        //assert
    }

    [TestMethod]
    public void AsSystemType_ShouldHaveProvidedValue()
    {
        //arrange
        StringPartitionKeyValue subject = new("the_value");

        //act
        PartitionKey actual = subject.AsSystemType();

        //assert
        actual.Should().Be(new PartitionKey("the_value"));
    }
}