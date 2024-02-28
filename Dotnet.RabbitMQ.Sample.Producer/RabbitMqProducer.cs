using System.Text;
using RabbitMQ.Client;

namespace Dotnet.RabbitMQ.Sample.Producer;

public class RabbitMqProducer
{
    public void PublishMessage(string message)
    {
        var factory = new ConnectionFactory() { HostName = "localhost" }; /// for this example

        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();
        channel.QueueDeclare(queue: "rice_queue",
            durable: false, 
            exclusive: false, 
            autoDelete: false, 
            arguments: null);

        var body = Encoding.UTF8.GetBytes(message);
            
        channel.BasicPublish(exchange: "", 
            routingKey: "rice_queue", 
            basicProperties: null,
            body: body);
            
        Console.WriteLine(" [x] Sent {0}", message);
    }
}