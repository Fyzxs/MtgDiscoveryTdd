using System;
using System.Threading.Tasks;
using Lib.Universal.Cache;

namespace Lib.Universal.Tests.Cache;

[TestClass]
public sealed class ClassCacheAsyncTests
{
    [TestMethod, TestCategory("unit")]
    public void ClassCacheAsync_ShouldExist()
    {
        //arrange

        //act
        ClassCacheAsync<string> _ = new();

        //assert
    }

    [TestMethod, TestCategory("unit")]
    public void ClassCacheAsync_ShouldImplementICacheAsync()
    {
        //arrange
        Type subject = typeof(ClassCacheAsync<string>);

        //act
        bool actual = typeof(ICacheAsync<string>).IsAssignableFrom(subject);

        //assert
        _ = actual.Should().BeTrue();
    }

    [TestMethod, TestCategory("unit")]
    public async Task Retrieve_ShouldReturnFuncResult()
    {
        //arrange
        ClassCacheAsync<string> subject = new();
        const string expected = "test value";

        //act
        string actual = await subject.Retrieve(() => Task.FromResult(expected)).ConfigureAwait(false);

        //assert
        _ = actual.Should().Be(expected);
    }

    [TestMethod, TestCategory("unit")]
    public async Task Retrieve_ShouldCacheValue()
    {
        //arrange
        ClassCacheAsync<string> subject = new();
        const string expected = "cached value";
        _ = await subject.Retrieve(() => Task.FromResult(expected)).ConfigureAwait(false);

        //act
        string actual = await subject.Retrieve(() => Task.FromResult("different value")).ConfigureAwait(false);

        //assert
        _ = actual.Should().Be(expected);
    }

    [TestMethod, TestCategory("unit")]
    public async Task Clear_ShouldClearCache()
    {
        //arrange
        ClassCacheAsync<string> subject = new();
        const string firstValue = "first";
        const string secondValue = "second";
        _ = await subject.Retrieve(() => Task.FromResult(firstValue)).ConfigureAwait(false);

        //act
        await subject.Clear().ConfigureAwait(false);
        string actual = await subject.Retrieve(() => Task.FromResult(secondValue)).ConfigureAwait(false);

        //assert
        _ = actual.Should().Be(secondValue);
    }
}