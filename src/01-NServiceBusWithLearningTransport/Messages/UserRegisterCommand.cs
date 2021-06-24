using System;
using NServiceBus;

namespace Messages
{
    public class UserRegisterCommand : ICommand
    {
        public string UserName { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
