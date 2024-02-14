using Blue.Calculadora.RabbitMQ.Interfaces;
using Blue.Calculadora.Shareable.Exceptions;
using Blue.Calculadora.Shareable.Requests;
using Blue.Calculadora.Shareable.Responses;
using MediatR;

public class AtualizarCadastroHandler : IRequestHandler<AtualizarContatoRequest, OperacaoAgendaResponse>
{
    private readonly IConnectionRabbitMQ _rabbitMQConnection;

    public AtualizarCadastroHandler(IConnectionRabbitMQ rabbitMQConnection)
    {
        _rabbitMQConnection = rabbitMQConnection;
    }

    public Task<OperacaoAgendaResponse> Handle(AtualizarContatoRequest request, CancellationToken cancellationToken)
    {
        OperacaoAgendaResponse? operacaoAgendaResponse = new OperacaoAgendaResponse();
        // Lógica de manipulação do comando AdicionarContatoRequest
        if (request == null)
        {
            throw new RequestNullException("A solicitação não pode ser nula.");
        }

        request.TipoOperacao = "AtualizarContato";
        operacaoAgendaResponse = _rabbitMQConnection.PublishMessage("Contato", request);
        operacaoAgendaResponse.mensagem = "Atualização do contato realizada com sucesso !";

        return Task.FromResult(operacaoAgendaResponse);
    }
}