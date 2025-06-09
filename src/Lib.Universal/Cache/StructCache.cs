using System;
using System.Threading.Tasks;

namespace Lib.Universal.Cache;

public sealed class StructCache<T> : ICacheAsync<T> where T : struct
{
    private T _cache;
    private bool _hasCachedValue;
    public async Task<T> Retrieve(Func<Task<T>> func)
    {
        await SetValue(func).ConfigureAwait(false);

        return _cache;
    }

    private async Task SetValue(Func<Task<T>> func)
    {
        if (_hasCachedValue) return;

        _cache = await func().ConfigureAwait(false);
        _hasCachedValue = true;
    }

    public Task Clear()
    {
        _hasCachedValue = false;
        return Task.CompletedTask;
    }
}