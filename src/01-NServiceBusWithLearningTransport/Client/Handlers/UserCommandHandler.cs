using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messages;
using NServiceBus;

namespace Client.Handlers
{
    public class UserCommandHandler : IHandleMessages<UserRegisterCommand>
    {
        public Task Handle(UserRegisterCommand message, IMessageHandlerContext context)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"User {message.UserName} created at {message.CreateDate}");
            return Task.CompletedTask;
        }
    }
}
