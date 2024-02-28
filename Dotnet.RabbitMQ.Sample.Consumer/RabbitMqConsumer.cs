using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Dotnet.RabbitMQ.Sample.Consumer;

public class RabbitMqConsumer
{
    public void ConsumerMessages()
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };

        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();
        channel.QueueDeclare(queue: "rice_queue",
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine(" [x] Message Received: {0}", message);
        };

        channel.BasicConsume(queue: "rice_queue",
            autoAck: true,
            consumer: consumer);
        
        Console.Write("Consumer is waiting for messages. Press any key to stop.");
        Console.ReadLine();
    }
}