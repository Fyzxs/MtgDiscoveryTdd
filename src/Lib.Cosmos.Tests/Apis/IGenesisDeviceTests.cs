using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Lib.Cosmos.Apis;

namespace Lib.Cosmos.Tests.Apis;

[TestClass]
public sealed class IGenesisDeviceTests
{
    [TestMethod, TestCategory("unit")]
    public void IGenesisDevice_ShouldExist()
    {
        //arrange

        //act
        Type type = typeof(IGenesisDevice);

        //assert
        _ = type.Should().NotBeNull();
        _ = type.IsInterface.Should().BeTrue();
    }

    [TestMethod, TestCategory("unit")]
    public void EnsureContainerAsync_ShouldExist()
    {
        //arrange
        Type type = typeof(IGenesisDevice);

        //act
        MethodInfo method = type.GetMethod(nameof(IGenesisDevice.EnsureContainerAsync));

        //assert
        _ = method.Should().NotBeNull();
    }

    [TestMethod, TestCategory("unit")]
    public void EnsureContainerAsync_ShouldReturnTask()
    {
        //arrange
        Type type = typeof(IGenesisDevice);

        //act
        MethodInfo method = type.GetMethod(nameof(IGenesisDevice.EnsureContainerAsync));

        //assert
        _ = method?.ReturnType.Should().Be(typeof(Task));
    }

    [TestMethod, TestCategory("unit")]
    public void EnsureContainerAsync_ShouldHaveCancellationTokenParameter()
    {
        //arrange
        Type type = typeof(IGenesisDevice);

        //act
        MethodInfo method = type.GetMethod(nameof(IGenesisDevice.EnsureContainerAsync));
        ParameterInfo[] parameters = method?.GetParameters();

        //assert
        _ = parameters?.Should().HaveCount(1);
        _ = parameters?[0].ParameterType.Should().Be(typeof(CancellationToken));
        _ = parameters?[0].HasDefaultValue.Should().BeTrue();
    }
}