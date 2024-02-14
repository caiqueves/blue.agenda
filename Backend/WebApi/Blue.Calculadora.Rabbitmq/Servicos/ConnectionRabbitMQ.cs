using Blue.Calculadora.RabbitMQ.Interfaces;
using Blue.Calculadora.Shareable.Config;
using Blue.Calculadora.Shareable.Exceptions;
using Blue.Calculadora.Shareable.Responses;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using System.Text;

namespace Blue.Calculadora.RabbitMQ.Servicos
{

    public class ConnectionRabbitMQ : IConnectionRabbitMQ
    {
        private readonly RabbitMQConfig _rabbitMQConfig;

        public ConnectionRabbitMQ(IOptions<RabbitMQConfig> rabbitMQConfig)
        {
            _rabbitMQConfig = rabbitMQConfig.Value;
            CreateModel();
        }

        public IModel CreateModel()
        {
            try
            {
                var connectionFactory = new ConnectionFactory
                {
                    HostName = _rabbitMQConfig.HostName,
                    Port = _rabbitMQConfig.Port,
                    UserName = _rabbitMQConfig.UserName,
                    Password = _rabbitMQConfig.Password
                    // Adicione outras configurações, se necessário
                };


                var connection = connectionFactory.CreateConnection();
                return connection.CreateModel();
            }
            catch (BrokerUnreachableException ex)
            {
                throw ex;
            }
            catch (AlreadyClosedException ex)
            {
                throw ex;
            }
            catch (OperationInterruptedException ex)
            {
                throw ex;
            }
            catch (PossibleAuthenticationFailureException ex)
            {
                throw ex;
            }
            
        }

        public void CreateQueue(string queueName)
        {
            var model = CreateModel();
            // Declaração de uma fila durável
            model.QueueDeclare(queue: queueName,
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

        }

        public OperacaoAgendaResponse PublishMessage(string queueName, object message)
        {
            OperacaoAgendaResponse operacaoAgendaResponse = new OperacaoAgendaResponse();
            
            try
            {
                CreateQueue(queueName);

                using (var channel = CreateModel())
                {
                    var objectMensagem = JsonConvert.SerializeObject(message);
                    var body = Encoding.UTF8.GetBytes(objectMensagem);

                    channel.BasicPublish(exchange: "",
                                         routingKey: queueName,
                                         basicProperties: null,
                                         body: body);

                    Console.WriteLine($" [x] Sent '{message}' to queue '{queueName}'");

                    operacaoAgendaResponse.status = "Sucesso";
                    operacaoAgendaResponse.mensagem = "";
                }
            }
            catch (BrokerUnreachableException ex)
            {
                operacaoAgendaResponse.status = "Falha";
                operacaoAgendaResponse.mensagem = ex.Message;
            }
            catch (AlreadyClosedException ex)
            {
                operacaoAgendaResponse.status = "Falha";
                operacaoAgendaResponse.mensagem = ex.Message;
            }
            catch (OperationInterruptedException ex)
            {
                operacaoAgendaResponse.status = "Falha";
                operacaoAgendaResponse.mensagem = ex.Message;
            }
            catch (PossibleAuthenticationFailureException ex)
            {
                operacaoAgendaResponse.status = "Falha";
                operacaoAgendaResponse.mensagem = ex.Message;
            }

            return operacaoAgendaResponse;
        }
    }
}
