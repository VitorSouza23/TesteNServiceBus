using NServiceBus;
using static System.Console;

Title = "Sales";

var endpointConfiguration = new EndpointConfiguration("Sales");
var transport = endpointConfiguration.UseTransport<LearningTransport>();

var endpointInstance = await Endpoint.Start(endpointConfiguration).ConfigureAwait(false);

WriteLine("Press enter to exit.");
ReadLine();

await endpointInstance.Stop().ConfigureAwait(false);