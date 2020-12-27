using Basket.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Repositories
{
    public interface IBasketRepository
    {
        Task<BasketCart> GetBasket(string userName);

        Task<BasketCart> UpdateBasket(BasketCart basket);

        Task<Boolean> DeleteBasket(string userName);
    }
}