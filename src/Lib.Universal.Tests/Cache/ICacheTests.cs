using System;
using Lib.Universal.Cache;

namespace Lib.Universal.Tests.Cache;

[TestClass]
public sealed class ICacheTests
{
    [TestMethod, TestCategory("unit")]
    public void ICache_ShouldExist()
    {
        //arrange
        Type subject = typeof(ICache<>);

        //act
        bool actual = subject.IsInterface;

        //assert
        _ = actual.Should().BeTrue();
    }
}
