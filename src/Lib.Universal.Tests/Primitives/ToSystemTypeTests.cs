using System;
using Lib.Universal.Primitives;

namespace Lib.Universal.Tests.Primitives;

[TestClass]
public sealed class ToSystemTypeTests
{
    [TestMethod, TestCategory("unit")]
    public void ToSystemType_ShouldExist()
    {
        //arrange

        //act
        ToSystemType _ = new TestToSystemType();

        //assert
    }

    [TestMethod, TestCategory("unit")]
    public void ToSystemType_ShouldBeAbstract()
    {
        //arrange
        Type subject = typeof(ToSystemType);

        //act
        bool actual = subject.IsAbstract;

        //assert
        _ = actual.Should().BeTrue();
    }

    private sealed class TestToSystemType : ToSystemType
    { }
}
