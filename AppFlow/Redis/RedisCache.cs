using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Caching.Distributed;
using AppFlow.Models;
using System.Text;
using Newtonsoft.Json;

namespace AppFlow.Redis
{
    public interface IRedisCacheService
    {
        public string CacheKey { get; set; }
        public DistributedCacheEntryOptions SetRedisProperty();
        public Task SerializeData(IEnumerable<HomeModel> data, string CacheKey);
        public IEnumerable<HomeModel> DeserializeData(byte[] getCachedData);
        public Task<byte[]> GetCachedData(string key);
        public IEnumerable<HomeModel> GetData(byte[] key);
    }
    public class RedisCacheService : IRedisCacheService
    {
        private readonly IConfiguration _configuration;
        private readonly IDistributedCache _distributedCache;
        public RedisCacheService(
            IConfiguration configuration,
            IDistributedCache distributedCache
            )
        {
            _configuration = configuration;
            _distributedCache = distributedCache;
        }
        public string CacheKey { get; set; }
        public DistributedCacheEntryOptions SetRedisProperty()
        {
            var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(2))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(1));
            return options;
        }

        public async Task SerializeData(IEnumerable<HomeModel> data, string CacheKey)
        {
            var serializeData = JsonConvert.SerializeObject(data);
            var encodedString = Encoding.UTF8.GetBytes(serializeData);
            await _distributedCache.SetAsync(CacheKey, encodedString, SetRedisProperty());
        }

        public IEnumerable<HomeModel> DeserializeData(byte[] getCachedData)
        {
            var decodedString = Encoding.UTF8.GetString(getCachedData);
            var deserializedData = JsonConvert.DeserializeObject<IEnumerable<HomeModel>>(decodedString);
            return deserializedData;
        }

        public async Task<byte[]> GetCachedData(string key)
        {
            byte[] cachedData = await _distributedCache.GetAsync(key);
            return cachedData;
        }

        public IEnumerable<HomeModel> GetData(byte[] cachedData)
        {
            var deserializedData = DeserializeData(cachedData);
            return deserializedData;
        }
    }
}
