using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lib.Universal.Cache;

public sealed class BlockingClassCache<T> : ICacheAsync<T> where T : class
{
    private readonly SemaphoreSlim _semaphore;
    private readonly ICacheAsync<T> _cache;

    public BlockingClassCache() : this(new SemaphoreSlim(1, 1), new ClassCacheAsync<T>()) { }

    private BlockingClassCache(SemaphoreSlim semaphore, ICacheAsync<T> cache)
    {
        _semaphore = semaphore;
        _cache = cache;
    }

    public async Task<T> Retrieve(Func<Task<T>> func)
    {
        await _semaphore.WaitAsync().ConfigureAwait(false);
        try
        {
            return await _cache.Retrieve(func).ConfigureAwait(false);
        }
        finally
        {
            _ = _semaphore.Release();
        }
    }

    public async Task Clear()
    {
        await _semaphore.WaitAsync().ConfigureAwait(false);
        try
        {
            await _cache.Clear().ConfigureAwait(false);
        }
        finally
        {
            _ = _semaphore.Release();
        }
    }
}
