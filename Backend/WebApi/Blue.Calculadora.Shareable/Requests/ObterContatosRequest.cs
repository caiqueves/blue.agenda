using Blue.Calculadora.Shareable.Responses;
using MediatR;

namespace Blue.Calculadora.Shareable.Requests
{
    public class ObterContatosRequest : IRequest<ObterContatosResponse>
    {
        public int Id { get; set; }

        public string? TipoOperacao { get; set; }

        public ObterContatosRequest(int id, string tipoOperacao)
        {
            Id = id;
            TipoOperacao = tipoOperacao;
        }
    }
}
