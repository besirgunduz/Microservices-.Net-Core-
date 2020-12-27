using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Models
{
    public class BasketCart
    {
        public string UserName { get; set; }
        public List<BasketCardItem> Items { get; set; } = new List<BasketCardItem>();

        public BasketCart()
        {
        }

        public BasketCart(string userName)
        {
            UserName = userName;
        }

        public Decimal TotalPrice
        {
            get
            {
                decimal totalPrice = 0;

                foreach (var i in Items)
                {
                    totalPrice += i.Price;
                }

                return totalPrice;
            }
        }
    }
}