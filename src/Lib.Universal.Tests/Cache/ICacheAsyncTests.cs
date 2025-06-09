using System;
using System.Threading.Tasks;
using Lib.Universal.Cache;

namespace Lib.Universal.Tests.Cache;

[TestClass]
public sealed class ICacheAsyncTests
{
    [TestMethod, TestCategory("unit")]
    public void ICacheAsync_ShouldExist()
    {
        //arrange
        Type subject = typeof(ICacheAsync<>);

        //act
        bool actual = subject.IsInterface;

        //assert
        _ = actual.Should().BeTrue();
    }
}