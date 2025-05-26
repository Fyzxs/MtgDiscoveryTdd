using Lib.Cosmos.Apis.Queries;
using Microsoft.Azure.Cosmos;

namespace Lib.Cosmos.Tests.Apis.Queries;

[TestClass]
public class ParameterizedQueryDefinitionTests
{
    [TestMethod]
    public void ShouldExist()
    {
        //arrange
        ParameterizedQueryDefinition _ = new TestParameterizedQueryDefinition(null);

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

    [TestMethod]
    public void AddParameter_ShouldReturnClass()
    {
        //arrange
        QueryString queryString = new("some string");
        ParameterizedQueryDefinition subject = new TestParameterizedQueryDefinition(queryString);

        //act
        ParameterizedQueryDefinition actual = subject.WithParameter("@param1", "value1");

        //assert
        actual.Should().BeSameAs(subject);
    }

    [TestMethod]
    public void AddParameter_ShouldAddParam()
    {
        //arrange
        QueryString queryString = new("some string");
        ParameterizedQueryDefinition subject = new TestParameterizedQueryDefinition(queryString);

        //act
        QueryDefinition actual = subject
                                        .WithParameter("@param1", "value1")
                                        .WithParameter("@param2", "value2").AsSystemType();

        //assert
        (string name1, object value1) valueTuple1 = actual.GetQueryParameters()[0];
        (string name2, object value2) valueTuple2 = actual.GetQueryParameters()[1];
        valueTuple1.name1.Should().Be("@param1");
        valueTuple1.value1.Should().Be("value1");
        valueTuple2.name2.Should().Be("@param2");
        valueTuple2.value2.Should().Be("value2");
    }

    private sealed class TestParameterizedQueryDefinition : ParameterizedQueryDefinition
    {
        public TestParameterizedQueryDefinition(QueryString queryString) : base(queryString) { }
    }
}