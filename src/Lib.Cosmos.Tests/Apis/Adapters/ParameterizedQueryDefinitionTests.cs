using Lib.Cosmos.Primitives;
using Lib.Universal.Primitives;
using Microsoft.Azure.Cosmos;

namespace Lib.Cosmos.Tests.Apis.Adapters;

[TestClass]
public class ParameterizedQueryDefinitionTests
{
    [TestMethod]
    public void ShouldExist()
    {
        //arrange
        ParameterizedQueryDefinition _ = new TestParameterizedQueryDefinition();

        //act

        //assert
    }

    [TestMethod]
    public void Ctor_ShouldTakeQueryDefinition()
    {
        //arrange
        QueryString queryString = new("some string");
        ParameterizedQueryDefinition subject = new TestParameterizedQueryDefinition(queryString);

        //act

        //assert
    }

    private sealed class TestParameterizedQueryDefinition : ParameterizedQueryDefinition
    {
        private readonly QueryString _queryString;

        public TestParameterizedQueryDefinition(QueryString queryString)
        {
            _queryString = queryString;
        }

        public override QueryDefinition AsSystemType() => throw new System.NotImplementedException();
    }
}

public abstract class ParameterizedQueryDefinition : ToSystemType<QueryDefinition>
{
}

