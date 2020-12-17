using NServiceBus;
using static System.Console;

Title = "Shipping";

var endpointConfiguration = new EndpointConfiguration("Shipping");
var transport = endpointConfiguration.UseTransport<LearningTransport>();

var endpointInstance = await Endpoint.Start(endpointConfiguration).ConfigureAwait(false);

WriteLine("Press enter to exit.");
ReadLine();

await endpointInstance.Stop().ConfigureAwait(false);