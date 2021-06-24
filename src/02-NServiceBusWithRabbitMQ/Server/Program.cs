using System;
using Messages;
using NServiceBus;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Server app";
            var configuration = new EndpointConfiguration("Server");
            RabbitMqConfig(configuration);
             var endpoint = Endpoint.Start(configuration).Result;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Press enter to send message ...");
                Console.ReadLine();
                var userRegisterCommand = new UserRegisterCommand
                {
                    UserName = "User " + Guid.NewGuid(),
                    CreateDate = DateTime.Now
                };

                endpoint.Send("Client", userRegisterCommand).Wait();
            }
        }

        private static void RabbitMqConfig(EndpointConfiguration configuration)
        {
            configuration.SendFailedMessagesTo("Server.Errors");
            configuration.EnableInstallers();
            var transport = configuration.UseTransport<RabbitMQTransport>();
            transport.UseConventionalRoutingTopology();
            transport.ConnectionString("host=localhost");
        }
    }
}
