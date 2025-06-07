using System;
using System.Threading.Tasks;

namespace Lib.Universal.Cache;

public interface ICacheAsync<T>
{
    Task<T> Retrieve(Func<Task<T>> func);
    Task Clear();
}