
using Blue.Calculadora.Domain.Interfaces;
using Blue.Calculadora.Infra.Data;
using Blue.Calculadora.RabbitMQ.Interfaces;
using Blue.Calculadora.Shareable.Config;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading.Channels;

public class CalculadoraWorker : BackgroundService
{
    private readonly RabbitMQConfig _rabbitMQConfig;
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly IServiceProvider _serviceProvider;

    public CalculadoraWorker(IOptions<RabbitMQConfig> rabbitmq,IServiceProvider serviceProvider)
    {
        _rabbitMQConfig = rabbitmq.Value;
        _serviceProvider = serviceProvider;

        var factory = new ConnectionFactory
        {
            HostName = "localhost",
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
        _channel.QueueDeclare(
            queue: "Contatos",
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine("Iniciando o processamento das mensagens ...");
        var consumer = new EventingBasicConsumer(_channel);

        consumer.Received += (sender, eventArgs) =>
        {
            var body = eventArgs.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine($"Lendo a mensagem: {message} of Queue: Contato");

            ProcessMessage(message);
            Console.WriteLine($"Processamento da mensagem: {message} of Queue: Contato, feita com sucesso !");
            _channel.BasicAck(eventArgs.DeliveryTag, false);
        };

        _channel.BasicConsume("Contato", false, consumer);

        return Task.CompletedTask;
    }

    public void ProcessMessage(string message)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var messageHandlingService = scope.ServiceProvider.GetRequiredService<IMessageHandlingService>();
            messageHandlingService.HandleMessage(message);
        }
    }
}
