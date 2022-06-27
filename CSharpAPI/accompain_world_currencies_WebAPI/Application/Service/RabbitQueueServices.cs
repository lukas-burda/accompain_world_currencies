using accompain_world_currencies_WebAPI.Application.Interfaces;
using accompain_world_currencies_WebAPI.Application.Models;
using accompain_world_currencies_WebAPI.Data.Models;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Npgsql;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace accompain_world_currencies_WebAPI.Application.Service
{
    public class RabbitQueueServices : IRabbitQueueServices
    {
        private readonly IConfiguration _configuration;

        public RabbitQueueServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public CosmosCurrencyValues ConsumeQueue()
        {
            CosmosCurrencyValues cosmosCurrency = new();

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

                var message = "";

                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    message = Encoding.UTF8.GetString(body);

                    cosmosCurrency = JsonConvert.DeserializeObject<CosmosCurrencyValues>(message);

                    Console.WriteLine(" [x] Received {0}", message);
                };

                channel.BasicConsume(queue: "mensagem",
                                     autoAck: true,
                                     consumer: consumer);

                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("Connection");
                NpgsqlDataReader myReader;

                using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    foreach (var item in cosmosCurrency.Currencies)
                    {
                        string query = @"insert into currencies(name, value) values (@name, @value)";

                        using (NpgsqlCommand mycommand = new NpgsqlCommand(query, myCon))
                        {
                            mycommand.Parameters.AddWithValue("@name", item.Name);
                            mycommand.Parameters.AddWithValue("@value", item.Value);
                            myReader = mycommand.ExecuteReader();
                            table.Load(myReader);

                            myReader.Close();
                        }
                    }
                    myCon.Close();
                }

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }


            return cosmosCurrency;
        }
    }
}
