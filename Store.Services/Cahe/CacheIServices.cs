using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.Services.Cahe
{
    public class CacheIServices : IcacheIServices
    {
        private readonly IDatabase _database;
        public CacheIServices(IConnectionMultiplexer redis)
        {
            _database=redis.GetDatabase();
        }
        public async Task<string> GetCacheResponseAsync(string key)
        {
            var cachedRespons=await _database.StringGetAsync(key);
            if (cachedRespons.IsNullOrEmpty)
                return null;
            return cachedRespons.ToString();
        }

        public async Task SetCacheResponseAsync(string key, object response, TimeSpan time)
        {
            if (response == null)
                return;
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var seralizedRespons = JsonSerializer.Serialize(response, options);
            await _database.StringSetAsync(key, seralizedRespons, time);
        }
    }
}
