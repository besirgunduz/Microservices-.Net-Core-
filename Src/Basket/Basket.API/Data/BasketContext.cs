using Basket.API.Data.Interfaces;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Data
{
    public class BasketContext : IBasketContext
    {
        private readonly ConnectionMultiplexer _redisConnections;

        public BasketContext(ConnectionMultiplexer redisConnections)
        {
            _redisConnections = redisConnections;

            Redis = _redisConnections.GetDatabase();
        }

        public IDatabase Redis { get; }
    }
}