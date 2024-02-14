using Blue.Calculadora.Shareable.Responses;
using MediatR;

namespace Blue.Calculadora.Shareable.Requests
{
    public class ObterContatoRequest : IRequest<ObterContatoResponse>
    {
        public int ContatoId { get; set; }

        public string? TipoOperacao { get; set; }

        public ObterContatoRequest(int contatoId, string tipoOperacao)
        {
            ContatoId = contatoId;
            TipoOperacao = tipoOperacao;
        }
    }
}
