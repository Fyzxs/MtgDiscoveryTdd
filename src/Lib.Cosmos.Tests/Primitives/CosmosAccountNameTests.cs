using System;
using Lib.Cosmos.Primitives;
using Lib.Universal.Primitives;

namespace Lib.Cosmos.Tests.Primitives;

[TestClass]
public sealed class CosmosAccountNameTests
{
    [TestMethod, TestCategory("unit")]
    public void CosmosAccountName_ShouldBeAbstract()
    {
        //arrange
        Type subject = typeof(CosmosAccountName);

        //act
        bool actual = subject.IsAbstract;

        //assert
        _ = actual.Should().BeTrue();
    }

    [TestMethod, TestCategory("unit")]
    public void CosmosAccountName_ShouldDeriveFromToSystemType()
    {
        //arrange
        Type subject = typeof(CosmosAccountName);

        //act
        bool actual = subject.IsSubclassOf(typeof(ToSystemType<string>));

        //assert
        _ = actual.Should().BeTrue();
    }
}
