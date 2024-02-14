using Blue.Calculadora.RabbitMQ.Interfaces;
using Blue.Calculadora.Shareable.Exceptions;
using Blue.Calculadora.Shareable.Requests;
using Blue.Calculadora.Shareable.Responses;
using MediatR;

public class RemoverContatoHandler : IRequestHandler<RemoverContatoRequest, OperacaoAgendaResponse>
{
    private readonly IConnectionRabbitMQ _rabbitMQConnection;

    public RemoverContatoHandler(IConnectionRabbitMQ rabbitMQConnection)
    {
        _rabbitMQConnection = rabbitMQConnection;
    }

    public Task<OperacaoAgendaResponse> Handle(RemoverContatoRequest request, CancellationToken cancellationToken)
    {
        OperacaoAgendaResponse? operacaoAgendaResponse = new OperacaoAgendaResponse();
        // Lógica de manipulação do comando AdicionarContatoRequest
        if (request == null)
        {
            throw new RequestNullException("A solicitação não pode ser nula.");
        }

        request.TipoOperacao = "RemoverContato";
        operacaoAgendaResponse = _rabbitMQConnection.PublishMessage("Contato", request);
        operacaoAgendaResponse.mensagem = "Deleção do contato realizada com sucesso !";

        return Task.FromResult(operacaoAgendaResponse);
    }
}