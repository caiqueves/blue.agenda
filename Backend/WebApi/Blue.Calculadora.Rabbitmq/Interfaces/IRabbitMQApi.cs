namespace Blue.Calculadora.RabbitMQ.Interfaces
{
    public interface IRabbitMQApi
    {
        Task PublishMessage(string message);
    }
}



