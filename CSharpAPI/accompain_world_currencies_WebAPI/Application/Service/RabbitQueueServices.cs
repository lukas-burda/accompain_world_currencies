using accompain_world_currencies_WebAPI.Application.Interfaces;
using accompain_world_currencies_WebAPI.Data.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace accompain_world_currencies_WebAPI.Application.Service
{
    public class RabbitQueueServices : IRabbitQueueServices
    {
        private readonly ICurrencyValueRepository _currencyValueRepository;

        public RabbitQueueServices( ICurrencyValueRepository repository)
        {
            _currencyValueRepository = repository;
        }

        public CurrencyValues ConsumeQueue()
        {
            CurrencyValues cosmosCurrency = new();

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "mensagem",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);

                    cosmosCurrency = JsonConvert.DeserializeObject<CurrencyValues>(message);

                    Console.WriteLine(" [x] Received {0}", message);
                };

                channel.BasicConsume(queue: "mensagem",
                                     autoAck: true,
                                     consumer: consumer);

                _currencyValueRepository.Save(cosmosCurrency);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }


            return cosmosCurrency;
        }
    }
}
