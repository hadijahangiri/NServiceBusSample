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
            configuration.UseTransport<LearningTransport>();
            var endpoint = Endpoint.Start(configuration).Result;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Press enter to send message ...");
                Console.ReadLine();

                var userRegisterCommand = new UserRegisterCommand
                {
                    UserName = "User " + Guid.NewGuid(),
                    CreateDate = DateTime.Now
                };

                endpoint.Send("Client", userRegisterCommand).Wait();
            }

        }
    }
}
