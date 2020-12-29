using RabbitMQ.Client;
using System;

namespace EventBusRabbitMQ
{
    public interface IRabbitMQConnection
    {
        bool IsConnected { get; }

        bool TryConnect();

        IModel CreateModel();
    }
}