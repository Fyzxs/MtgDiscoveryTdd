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

    private sealed class TestToSystemType : ToSystemType
    { }
}
