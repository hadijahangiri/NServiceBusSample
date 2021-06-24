using System;
using NServiceBus;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Client app";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Waiting for receive message ...");
            var configuration = new EndpointConfiguration("Client");
             RabbitMqConfig(configuration);
            var endpoint = Endpoint.Start(configuration).Result;

            Console.ReadLine();
        }

        private static void RabbitMqConfig(EndpointConfiguration configuration)
        {
            configuration.SendFailedMessagesTo("Client.Errors");
            configuration.EnableInstallers();
            var transport = configuration.UseTransport<RabbitMQTransport>();
            transport.UseConventionalRoutingTopology();
            transport.ConnectionString("host=localhost");
        }
    }
}
