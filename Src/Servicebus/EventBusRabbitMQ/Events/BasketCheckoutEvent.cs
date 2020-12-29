using System;

namespace EventBusRabbitMQ.Events
{
    public class BasketCheckoutEvent
    {
        public Guid RequestId { get; set; }

        public string UserName { get; set; }
        public decimal TotalPrice { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }
}