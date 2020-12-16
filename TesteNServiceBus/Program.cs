using Messages;
using NServiceBus;
using NServiceBus.Logging;
using System;
using System.Threading.Tasks;
using static System.Console;

ILog log = LogManager.GetLogger("Program");

Title = "ClientUI";
var endpointConfiguration = new EndpointConfiguration("ClientUI");
var trasnport = endpointConfiguration.UseTransport<LearningTransport>();

var routing = trasnport.Routing();
routing.RouteToEndpoint(typeof(PlaceOrder), "Sales");

var endpointInstance = await Endpoint.Start(endpointConfiguration).ConfigureAwait(false);

await RunLoop(endpointInstance).ConfigureAwait(false);

await endpointInstance.Stop().ConfigureAwait(false);


async Task RunLoop(IEndpointInstance endpointInstance)
{
    while (true)
    {
        log.Info("Press 'P' to send a message or 'Q' to quit.");
        var key = ReadKey();
        WriteLine();

        switch(key.Key)
        {
            case ConsoleKey.P: await SendMessage(endpointInstance); break;
            case ConsoleKey.Q: return;
            default: log.Info("Unkonw input. Please, try again."); break;
        };
    }
}

async Task SendMessage(IEndpointInstance endpointInstance)
{
    var command = new PlaceOrder { OrderId = Guid.NewGuid().ToString() };
    log.Info($"Send PlaceOrder command - OrderId: {command.OrderId}");
    await endpointInstance.Send(command).ConfigureAwait(false);
}