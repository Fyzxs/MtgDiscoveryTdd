using System;
using Lib.Universal.Primitives;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestConvenience.Universal.Tests;

public abstract class BaseToSystemTypeTests<TType, TSystemType>
{
    [TestMethod, TestCategory("unit")]
    public void Class_ShouldBeAbstract()
    {
        //arrange
        Type subject = typeof(TType);

        //act
        bool actual = subject.IsAbstract;

        //assert
        _ = actual.Should().BeTrue();
    }

    [TestMethod, TestCategory("unit")]
    public void ClassShouldDeriveFromToSystemType()
    {
        //arrange
        Type subject = typeof(TType);

        //act
        bool actual = subject.IsSubclassOf(typeof(ToSystemType<TSystemType>));

        //assert
        _ = actual.Should().BeTrue();
    }
}
