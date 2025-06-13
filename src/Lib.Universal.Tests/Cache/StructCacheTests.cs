using System;
using System.Threading.Tasks;
using Lib.Universal.Cache;

namespace Lib.Universal.Tests.Cache;

[TestClass]
public sealed class StructCacheTests
{
    [TestMethod, TestCategory("unit")]
    public void StructCache_ShouldExist()
    {
        //arrange

        //act
        StructCache<int> _ = new();

        //assert
    }

    [TestMethod, TestCategory("unit")]
    public void StructCache_ShouldImplementICacheAsync()
    {
        //arrange
        Type subject = typeof(StructCache<int>);

        //act
        bool actual = typeof(ICacheAsync<int>).IsAssignableFrom(subject);

        //assert
        _ = actual.Should().BeTrue();
    }

    [TestMethod, TestCategory("unit")]
    public async Task Retrieve_ShouldReturnFuncResult()
    {
        //arrange
        StructCache<int> subject = new();
        const int expected = 42;

        //act
        int actual = await subject.Retrieve(() => Task.FromResult(expected)).ConfigureAwait(false);

        //assert
        _ = actual.Should().Be(expected);
    }

    [TestMethod, TestCategory("unit")]
    public async Task Retrieve_ShouldCacheValue()
    {
        //arrange
        StructCache<int> subject = new();
        const int expected = 42;
        _ = await subject.Retrieve(() => Task.FromResult(expected)).ConfigureAwait(false);

        //act
        int actual = await subject.Retrieve(() => Task.FromResult(99)).ConfigureAwait(false);

        //assert
        _ = actual.Should().Be(expected);
    }

    [TestMethod, TestCategory("unit")]
    public async Task Clear_ShouldClearCache()
    {
        //arrange
        StructCache<int> subject = new();
        const int firstValue = 42;
        const int secondValue = 99;
        _ = await subject.Retrieve(() => Task.FromResult(firstValue)).ConfigureAwait(false);

        //act
        await subject.Clear().ConfigureAwait(false);
        int actual = await subject.Retrieve(() => Task.FromResult(secondValue)).ConfigureAwait(false);

        //assert
        _ = actual.Should().Be(secondValue);
    }
}
