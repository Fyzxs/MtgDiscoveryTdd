using System;
using Lib.Universal.Cache;

namespace Lib.Universal.Tests.Cache;

[TestClass]
public sealed class ClassCacheTests
{
    [TestMethod, TestCategory("unit")]
    public void ClassCache_ShouldExist()
    {
        //arrange

        //act
        ClassCache<string> _ = new();

        //assert
    }

    [TestMethod, TestCategory("unit")]
    public void ClassCache_ShouldImplementICache()
    {
        //arrange
        Type subject = typeof(ClassCache<string>);

        //act
        bool actual = typeof(ICache<string>).IsAssignableFrom(subject);

        //assert
        _ = actual.Should().BeTrue();
    }

    [TestMethod, TestCategory("unit")]
    public void Retrieve_ShouldReturnFuncResult()
    {
        //arrange
        ClassCache<string> subject = new();
        const string expected = "test value";

        //act
        string actual = subject.Retrieve(() => expected);

        //assert
        _ = actual.Should().Be(expected);
    }

    [TestMethod, TestCategory("unit")]
    public void Retrieve_ShouldCacheValue()
    {
        //arrange
        ClassCache<string> subject = new();
        const string expected = "cached value";
        _ = subject.Retrieve(() => expected);

        //act
        string actual = subject.Retrieve(() => "different value");

        //assert
        _ = actual.Should().Be(expected);
    }

    [TestMethod, TestCategory("unit")]
    public void Clear_ShouldClearCache()
    {
        //arrange
        ClassCache<string> subject = new();
        const string firstValue = "first";
        const string secondValue = "second";
        _ = subject.Retrieve(() => firstValue);

        //act
        subject.Clear();
        string actual = subject.Retrieve(() => secondValue);

        //assert
        _ = actual.Should().Be(secondValue);
    }
}