using Blue.Calculadora.Shareable.Responses;
using RabbitMQ.Client;

namespace Blue.Calculadora.RabbitMQ.Interfaces
{
    public interface IConnectionRabbitMQ
    {
        IModel CreateModel();
        void CreateQueue(string queueName);
        OperacaoAgendaResponse PublishMessage(string queueName, object mensagem );

    }
}

