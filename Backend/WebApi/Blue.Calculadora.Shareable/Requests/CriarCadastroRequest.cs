using Blue.Calculadora.Shareable.Responses;
using MediatR;

namespace Blue.Calculadora.Shareable.Requests
{
    public class CriarCadastroRequest : IRequest<OperacaoAgendaResponse>
    {
        public string? Name { get; set; }

        public string? Login { get; set; }

        public string? Senha { get; set; }

        public string? TipoOperacao { get; set; }

        public CriarCadastroRequest(string nome, string login, string senha, string? tipoOperacao)
        {
            Name = nome;
            Login = login;
            Senha = senha;
            TipoOperacao = tipoOperacao;
        }
    }
}
