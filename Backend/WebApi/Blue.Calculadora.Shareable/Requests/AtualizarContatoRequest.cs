using Blue.Calculadora.Shareable.Responses;
using MediatR;

namespace Blue.Calculadora.Shareable.Requests
{
    public class AtualizarContatoRequest : IRequest<OperacaoAgendaResponse>
    {
        public int ContatoId { get; set; }
        public string? NovoNome { get; set; }
        public string? NovoTelefone { get; set; }
        public string? NovoEmail { get; set; }

        public string? TipoOperacao { get; set; }

    }
}
