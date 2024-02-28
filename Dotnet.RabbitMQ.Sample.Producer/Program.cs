// See https://aka.ms/new-console-template for more information

using Dotnet.RabbitMQ.Sample.Producer;

string? message;

var producer = new RabbitMqProducer();

do
{
    Console.WriteLine("Sending a message");
    message = Console.ReadLine();
    if (message != null) producer.PublishMessage(message);
} while (!string.Equals(message, "exit", StringComparison.CurrentCultureIgnoreCase));