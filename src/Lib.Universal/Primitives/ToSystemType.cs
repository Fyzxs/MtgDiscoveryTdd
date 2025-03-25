using System.Diagnostics.CodeAnalysis;

namespace Lib.Universal.Primitives;

public abstract class ToSystemType<TSystemType>
{
    public static implicit operator TSystemType([NotNull] ToSystemType<TSystemType> source) => source.AsSystemType();

    public abstract TSystemType AsSystemType();

    public TSystemType ToTSystemType()
    {
        throw new System.NotImplementedException();
    }
}
