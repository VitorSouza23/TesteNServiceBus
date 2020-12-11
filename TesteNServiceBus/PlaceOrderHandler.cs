﻿using Messages;
using NServiceBus;
using NServiceBus.Logging;
using System.Threading.Tasks;

namespace ClientUI
{
    public class PlaceOrderHandler : IHandleMessages<PlaceOrder>
    {
        static ILog log = LogManager.GetLogger<PlaceOrderHandler>();
        public Task Handle(PlaceOrder message, IMessageHandlerContext context)
        {
            log.Info($"Received PlaceOrder - OrderID: {message.OrderId}");
            return Task.CompletedTask;
        }
    }
}
