using System;

namespace Lib.Universal.Cache;

public interface ICache<T>
{
    T Retrieve(Func<T> func);
    void Clear();
}