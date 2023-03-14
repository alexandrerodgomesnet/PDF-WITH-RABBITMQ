using System.Text;
using Core.Services.DTOs;
using Core.Services.Interfaces;
using RabbitMQ.Client;

namespace Core.Services
{
    public sealed class RabbitMQ : IMessageSender, IDisposable
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        public RabbitMQ()
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "user",
                Password = "password",
                Port = 5672
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }
        public void Publish(MessageSenderDataDto data)
        {
            string queueName = "reports-queue";
            string exchange = "reports-ex";
            string routingKey = "generate-report";

            _channel.ExchangeDeclare(
                exchange: exchange,
                type: "direct",
                durable: true,
                autoDelete: false,
                arguments: null
            );
            _channel.QueueDeclare(
                queue: queueName, 
                durable: true, 
                exclusive: false, 
                autoDelete: false, 
                arguments: null
            );

            _channel.QueueBind(
                queue: queueName, 
                exchange: exchange, 
                routingKey: routingKey
            );

            var body = Encoding.UTF8.GetBytes(data.linesCount.ToString());

            _channel.BasicPublish(
                exchange: exchange,
                routingKey: routingKey,
                basicProperties: null,
                body: body
            );
        }

        public void Dispose()
        {
            _connection.Dispose();
            _channel.Dispose();
        }
    }
}