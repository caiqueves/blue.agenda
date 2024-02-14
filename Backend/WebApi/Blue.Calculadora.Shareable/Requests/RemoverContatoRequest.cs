using Blue.Calculadora.Shareable.Responses;
using MediatR;

namespace Blue.Calculadora.Shareable.Requests
{
    public class RemoverContatoRequest : IRequest<OperacaoAgendaResponse>
    {
        public int ContatoId { get; set; }

        public string? TipoOperacao { get; set; }

        public RemoverContatoRequest(int contatoId, string tipoOperacao)
        {
            ContatoId = contatoId;
            TipoOperacao = tipoOperacao;
        }
    }

}
