using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Options;
using Blue.Calculadora.Shareable.Config;
using RabbitMQ.Client.Exceptions;
using Blue.Calculadora.Shareable.Responses;
using Blue.Calculadora.RabbitMQ.Interfaces;
using System.Threading.Channels;
using Blue.Calculadora.Domain.Interfaces;
using Blue.Calculadora.Infra.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Blue.Calculadora.RabbitMQ.Servicos
{
    public class ConsumerRabbitMQ : IConsumerRabbitMQ
    {
        private readonly RabbitMQConfig _rabbitMQConfig;
        private readonly IServiceProvider _serviceProvider;
        public ConsumerRabbitMQ(IOptions<RabbitMQConfig> rabbitMQConfig, IServiceProvider serviceProvider)
        {
            _rabbitMQConfig = rabbitMQConfig.Value ?? throw new ArgumentNullException(nameof(rabbitMQConfig));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException();
        }

        public Task Consume()
        {
            string message = string.Empty;
            string _queueName1 = "Contato";
           // string _queueName2 = "Usuario";

            
                var factory = new ConnectionFactory
                {
                    HostName = _rabbitMQConfig.HostName ?? "localhost",
                    Port = 5672,
                    UserName ="guest",
                    Password = "guest",
                    // Adicione outras configurações, se necessário
                };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    var consumer1 = new EventingBasicConsumer(channel);
                    consumer1.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);

                        ProcessMessage(message);
                        channel.BasicAck(ea.DeliveryTag, false);
                    };

                    //var consumer2 = new EventingBasicConsumer(channel);
                    //consumer2.Received += (model, ea) =>
                    //{
                    //    ProcessMessage(ea);
                    //    channel.BasicAck(ea.DeliveryTag, false);
                    //};

                    channel.BasicConsume(_queueName1,false, consumer1);

                    //channel.BasicConsume(queue: _queueName2, autoAck: false, consumer: consumer2);
                    return Task.CompletedTask;
                }
            //}
            //catch (BrokerUnreachableException ex)
            //{
            //    operacaoAgendaResponse.status = "Falha";
            //    operacaoAgendaResponse.mensagem = ex.Message;
            //    message = $"Failed to consume messages: {ex.Message}";
            //}
            //catch (AlreadyClosedException ex)
            //{
            //    operacaoAgendaResponse.status = "Falha";
            //    operacaoAgendaResponse.mensagem = ex.Message;
            //    message = $"Failed to consume messages: {ex.Message}";
            //}
            //catch (OperationInterruptedException ex)
            //{
            //    operacaoAgendaResponse.status = "Falha";
            //    operacaoAgendaResponse.mensagem = ex.Message;
            //    message = $"Failed to consume messages: {ex.Message}";
            //}
            //catch (PossibleAuthenticationFailureException ex)
            //{
            //    operacaoAgendaResponse.status = "Falha";
            //    operacaoAgendaResponse.mensagem = ex.Message;
            //    message = $"Failed to consume messages: {ex.Message}";
            //}
        }

        private void DeclareQueue(IModel channel, string queueName)
        {
            // Declaração básica de fila
            channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

        }

        private void ProcessMessage(string message)
        {
            using (var scope = _serviceProvider.CreateScope()) 
            { 
                var messageHandlingService = scope.ServiceProvider.GetRequiredService<IMessageHandlingService>();
                messageHandlingService.HandleMessage(message);
            }
        }

    }
}