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
        ToSystemType<string> _ = new TestToSystemType<string>();

        //assert
    }

    [TestMethod, TestCategory("unit")]
    public void ToSystemType_ShouldBeAbstract()
    {
        //arrange
        Type subject = typeof(ToSystemType<string>);

        //act
        bool actual = subject.IsAbstract;

        //assert
        _ = actual.Should().BeTrue();
    }

    [TestMethod, TestCategory("unit")]
    public void ToSystemType_ShouldBeHaveGeneric()
    {
        //arrange

        //act
        ToSystemType<string> _ = new TestToSystemType<string>();

        //assert
    }

    [TestMethod, TestCategory("unit")]
    public void ToSystemType_HaveAsSystemType()
    {
        //arrange
        ToSystemType<string> subject = new TestToSystemType<string>();

        //act
        string actual = subject.AsSystemType();

        //assert
        _ = actual.Should().Be(null);
    }

    private sealed class TestToSystemType<T> : ToSystemType<T>
    { }
}
