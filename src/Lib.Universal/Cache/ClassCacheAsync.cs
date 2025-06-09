using System;
using System.Threading.Tasks;

namespace Lib.Universal.Cache;

public sealed class ClassCacheAsync<T> : ICacheAsync<T> where T : class
{
    private T _cache;

    public async Task<T> Retrieve(Func<Task<T>> func) => _cache ??= await func().ConfigureAwait(false);

    public Task Clear()
    {
        _cache = null;
        return Task.CompletedTask;
    }
}

public sealed class ClassCache<T> : ICache<T> where T : class
{
    private T _cache;

    public T Retrieve(Func<T> func) => _cache ??= func();

    public void Clear() => _cache = null;
}