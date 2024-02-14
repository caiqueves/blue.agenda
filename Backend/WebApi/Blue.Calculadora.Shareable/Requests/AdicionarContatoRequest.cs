using Blue.Calculadora.Shareable.Responses;
using MediatR;

namespace Blue.Calculadora.Shareable.Requests
{
    public class AdicionarContatoRequest : IRequest<OperacaoAgendaResponse>
    {
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public string? TipoOperacao { get; set; }

    }
}
