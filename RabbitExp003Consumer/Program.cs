using Newtonsoft.Json;
using RabbitExp003Consumer.DataAccess;
using RabbitExp003Consumer.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Linq;
using System.Text;

namespace RabbitExp003Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionFactory = new ConnectionFactory
            {
                Uri = new Uri(Environment.GetEnvironmentVariable("RABBIT_URI"))
            };

            using (var connection = connectionFactory.CreateConnection())
              
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    if (ea.Body != null)
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        //Console.WriteLine(" Received {0}", message);
                        string json = JsonConvert.SerializeObject(message);
                        using (MongoRepository<PersonJson> mongoRepository = new MongoRepository<PersonJson>())
                        {
                            //var companyJson = JsonConvert.SerializeObject(company);
                            mongoRepository.Add(new PersonJson()
                            {
                                Companies = json
                            });
                            var ab = mongoRepository.GetAll().ToList();

                        }

                    }
 
                };
                channel.BasicConsume(queue: "hello",
                                     autoAck: true,
                                     consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
            //Console.WriteLine("Hello World!");
        }
    }
}
