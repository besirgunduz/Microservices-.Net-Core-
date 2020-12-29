using AutoMapper;
using Basket.API.Models;
using Basket.API.Repositories;
using EventBusRabbitMQ.Events;
using EventBusRabbitMQ.Producer;
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
        private readonly IMapper _mapper;
        private readonly EventBusRabbitMQProducer _eventProducer;

        public BasketController(IBasketRepository basketRepository, IMapper mapper, EventBusRabbitMQProducer eventProducer)
        {
            _basketRepository = basketRepository;

            _mapper = mapper;
            _eventProducer = eventProducer;
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

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Checkout(BasketCheckout basketCheckout)
        {
            var basket = await _basketRepository.GetBasket(basketCheckout.UserName);

            await _basketRepository.DeleteBasket(basketCheckout.UserName);

            var eventMessage = _mapper.Map<BasketCheckoutEvent>(basketCheckout);

            eventMessage.RequestId = Guid.NewGuid();
            eventMessage.TotalPrice = basket.TotalPrice;
            _eventProducer.PublishBasketCheckout(EventBusRabbitMQ.Common.EventBusConstants.BasketCheckoutQueue, eventMessage);

            return Ok();
        }
    }
}