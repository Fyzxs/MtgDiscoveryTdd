using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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

    [TestMethod, TestCategory("unit")]
    public void AsSystemType_ShouldReturnGeneric()
    {
        //arrange
        ToSystemType<int> subject = new TestToSystemType<int>();

        //act
        int actual = subject.AsSystemType();

        //assert
        _ = actual.Should().Be(0);
    }

    [TestMethod, TestCategory("unit")]
    public void AsSystemType_AsSystemTypeIsAbstract()
    {
        //arrange
        MethodInfo subject = typeof(ToSystemType<string>).GetMethod("AsSystemType")!;

        //act
        bool actual = subject.IsAbstract;

        //assert
        _ = actual.Should().BeTrue();
    }

    [TestMethod, TestCategory("unit")]
    public void ToSystemType_ShouldImplicitConvert()
    {
        //arrange
        ToSystemType<string> subject = new TestToSystemType<string>("hello");

        //act
        string actual = subject;

        //assert
        _ = actual.Should().Be("hello");
    }

    [TestMethod, TestCategory("unit")]
    public void ToString_ShouldStringOfValue()
    {
        //arrange
        ToSystemType<string> subject = new TestToSystemType<string>("hello");

        //act
        string actual = subject.ToString();

        //assert
        _ = actual.Should().Be("hello");
    }

    [TestMethod, TestCategory("unit")]
    public void DebuggerDisplay_ShouldBeExpectedValue()
    {
        //arrange
        Type type = typeof(ToSystemType<string>);
        DebuggerDisplayAttribute attribute = (DebuggerDisplayAttribute)type
            .GetCustomAttributes(typeof(DebuggerDisplayAttribute), false)
            .FirstOrDefault();

        //act
        string actual = attribute?.Value;

        //assert
        _ = actual.Should().Be("[{GetType().Name}]:{AsSystemType()}");
    }

    private sealed class TestToSystemType<T> : ToSystemType<T>
    {
        private readonly T _origin;

        public TestToSystemType(T origin = default) => _origin = origin;

        public override T AsSystemType() => _origin;
    }
}
