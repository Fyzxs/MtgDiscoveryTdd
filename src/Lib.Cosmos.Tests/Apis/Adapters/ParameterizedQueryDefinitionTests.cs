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
        ParameterizedQueryDefinition subject = new TestParameterizedQueryDefinition();

        //act

        //assert
    }

    private sealed class TestParameterizedQueryDefinition : ParameterizedQueryDefinition
    {
        public override QueryDefinition AsSystemType() => throw new System.NotImplementedException();
    }
}

public abstract class ParameterizedQueryDefinition : ToSystemType<QueryDefinition>
{
}

