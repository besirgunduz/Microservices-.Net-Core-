using Basket.API.Models;
using Basket.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;

        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasket(string userName)
        {
            var basket = await _basketRepository.GetBasket(userName);

            return Ok(basket);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBasket(BasketCart basketCart)
        {
            var basket = await _basketRepository.UpdateBasket(basketCart);

            return Ok(basket);
        }

        [HttpDelete("{userName}")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> DeleteBasket(string userName)
        {
            var basket = await _basketRepository.DeleteBasket(userName);

            return Ok(basket);
        }
    }
}