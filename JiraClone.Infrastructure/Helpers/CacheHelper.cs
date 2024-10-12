
using System.Text.Json;
using System.Threading;
using Microsoft.Extensions.Caching.Distributed;
using Polly;
using Polly.Retry;
using StackExchange.Redis;

namespace JiraClone.Infrastructure.Helpers
{
    public class CacheHelper : ICacheHelper
    {
        private readonly IDistributedCache _redisCache;
        private readonly AsyncRetryPolicy _retryPolicy;

        public CacheHelper(IDistributedCache redisCache)
        {
            _redisCache = redisCache;
            _retryPolicy = Policy
                .Handle<RedisConnectionException>()
                .Or<RedisTimeoutException>()
                .Or<RedisServerException>()
                .WaitAndRetryAsync(5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }


        public async Task AddAsync<T>(string key, T value, CancellationToken ct) where T : class
        {
            await SetValueAsync(key, value, ct);
        }

        public async Task<T?> TryGetAsync<T>(string key, CancellationToken ct) where T : class
        {
            var stringValue = await _retryPolicy.ExecuteAsync(async () =>
            {
                return await _redisCache.GetStringAsync(key, ct);

            });


            var result = string.IsNullOrWhiteSpace(stringValue) ? null : JsonSerializer.Deserialize<T>(stringValue);

            return result;
        }

        public async Task UpdateAsync<T>(string key, T value, CancellationToken ct) where T : class
        {
            await SetValueAsync(key, value, ct);
        }

        public async Task RemoveAsync(string key, CancellationToken ct)
        {
            await _retryPolicy.ExecuteAsync(async () =>
            {
                await _redisCache.RemoveAsync(key, ct);
            });
        }

        private async Task SetValueAsync<T>(string key, T value, CancellationToken ct) where T : class
        {

            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(3)
            };

            var stringValue = JsonSerializer.Serialize(value);

            await _redisCache.SetStringAsync(key, stringValue, options, ct);
        }
    }
}
