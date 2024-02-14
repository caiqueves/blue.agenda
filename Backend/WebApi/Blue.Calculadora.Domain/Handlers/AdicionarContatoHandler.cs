using Blue.Calculadora.RabbitMQ.Interfaces;
using Blue.Calculadora.Shareable.Exceptions;
using Blue.Calculadora.Shareable.Requests;
using Blue.Calculadora.Shareable.Responses;
using MediatR;

namespace Blue.Calculadora.Domain.Handlers
{
    public class AdicionarContatoHandler : IRequestHandler<AdicionarContatoRequest, OperacaoAgendaResponse>
    {
        private readonly IConnectionRabbitMQ _rabbitMQConnection;

        public AdicionarContatoHandler(IConnectionRabbitMQ rabbitMQConnection)
        {
            _rabbitMQConnection = rabbitMQConnection;
        }

        public Task<OperacaoAgendaResponse> Handle(AdicionarContatoRequest request, CancellationToken cancellationToken)
        {
            OperacaoAgendaResponse? operacaoAgendaResponse = new OperacaoAgendaResponse();
            // Lógica de manipulação do comando AdicionarContatoRequest
            if (request == null)
            {
                throw new RequestNullException("A solicitação não pode ser nula.");
            }

            request.TipoOperacao = "AdicionarContato";
            operacaoAgendaResponse = _rabbitMQConnection.PublishMessage("Contato", request);
            operacaoAgendaResponse.mensagem = "Cadastro do contato realizada com sucesso !";

            return Task.FromResult(operacaoAgendaResponse);
        }
    }
}