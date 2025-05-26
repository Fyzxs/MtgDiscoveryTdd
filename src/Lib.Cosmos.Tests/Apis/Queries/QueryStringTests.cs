using Lib.Cosmos.Apis.Queries;
using Lib.Universal.Primitives;
using Microsoft.Azure.Cosmos;

namespace Lib.Cosmos.Tests.Apis.Queries;

[TestClass]
public sealed class QueryStringTests
{
    [TestMethod]
    public void ShouldExist()
    {
        //arrange
        SimpleQueryDefinition _ = new QueryString("My Query String");

        //act

        //assert
    }

    [TestMethod]
    public void QueryDefinition_ShouldHaveProvided()
    {
        //arrange
        const string QueryString = "Does Not Matter";
        ToSystemType<QueryDefinition> subject = new QueryString(QueryString);

        //act
        QueryDefinition queryDefinition = subject.AsSystemType();

        //assert
        _ = queryDefinition.QueryText.Should().Be(QueryString);
    }
}
