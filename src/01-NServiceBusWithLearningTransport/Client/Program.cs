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
            configuration.UseTransport<LearningTransport>();
            var endpoint = Endpoint.Start(configuration).Result;

            Console.ReadLine();
        }
    }
}
