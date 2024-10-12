using System.Threading;

namespace JiraClone.Infrastructure.Helpers;

public interface ICacheHelper
{
    Task AddAsync<T>(string key, T value, CancellationToken ct) where T : class;
    Task<T?> TryGetAsync<T>(string key, CancellationToken ct) where T : class;
    Task UpdateAsync<T>(string key, T value, CancellationToken ct) where T : class;
    Task RemoveAsync(string key, CancellationToken ct);
}