using AutoMapper;
using Basket.API.Models;
using EventBusRabbitMQ.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Mapping
{
    public class DtoMapping : Profile
    {
        public DtoMapping()
        {
            CreateMap<BasketCheckout, BasketCheckoutEvent>();
        }
    }
}