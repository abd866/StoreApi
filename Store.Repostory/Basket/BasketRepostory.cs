using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using StackExchange.Redis;
using Store.Repostory.Basket.Models;
using IDatabase = StackExchange.Redis.IDatabase;

namespace Store.Repostory.Basket
{
    public class BasketRepostory : IBasketRepostory
    {

        private readonly IDatabase _database;
        public BasketRepostory(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }
        public  async Task<bool> DeleteBasketAsync(string id)
         => await _database.KeyDeleteAsync(id);

        public async  Task<CustomerBasket> GetBasketAsync(string id)
        {
            var basket = await _database.StringGetAsync(id);
            return basket.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(basket);
        }

        public async  Task<CustomerBasket> UpdateBasketAsync(CustomerBasket customer)
        {
            var IsCreated= await _database.StringSetAsync(customer.Id,JsonSerializer.Serialize(customer),TimeSpan.FromDays(30));
            if (!IsCreated)
                return null;
            return await GetBasketAsync(customer.Id);
        }
    }
}
