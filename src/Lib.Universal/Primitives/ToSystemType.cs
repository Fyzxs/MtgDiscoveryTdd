using System.Diagnostics;

namespace Lib.Universal.Primitives;

[DebuggerDisplay("[{GetType().Name}]:{AsSystemType()}")]
public abstract class ToSystemType<TSystemType>
{
    public static implicit operator TSystemType(ToSystemType<TSystemType> source) => source.AsSystemType();

    public abstract TSystemType AsSystemType();

    public override string ToString() => $"{AsSystemType()}";
}
