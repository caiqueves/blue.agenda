using Blue.Calculadora.RabbitMQ.Interfaces;
using Blue.Calculadora.Shareable.Exceptions;
using Blue.Calculadora.Shareable.Requests;
using Blue.Calculadora.Shareable.Responses;
using MediatR;

public class CriarCadastroHandler : IRequestHandler<CriarCadastroRequest, OperacaoAgendaResponse>
{
    private readonly IConnectionRabbitMQ _connectionRabbitMQ;

    public CriarCadastroHandler(IConnectionRabbitMQ connectionRabbitMQ)
    {
        _connectionRabbitMQ = connectionRabbitMQ;
    }

    public Task<OperacaoAgendaResponse> Handle(CriarCadastroRequest request, CancellationToken cancellationToken)
    {
        OperacaoAgendaResponse operacaoAgendaResponse = new OperacaoAgendaResponse();
        // Lógica de manipulação do comando AdicionarContatoRequest
        if (request == null)
        {
            throw new RequestNullException("A solicitação não pode ser nula.");
        }

        request.TipoOperacao = "CadastroUsuario";
        operacaoAgendaResponse = _connectionRabbitMQ.PublishMessage("Contato", request);
        operacaoAgendaResponse.mensagem = "Cadastro do usuário realizada com sucesso !";

        return Task.FromResult(operacaoAgendaResponse);
    }
}
