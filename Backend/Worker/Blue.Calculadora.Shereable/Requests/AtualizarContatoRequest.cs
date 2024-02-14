
namespace Blue.Calculadora.Shareable.Requests
{
    public class AtualizarContatoRequest 
    {
        public int ContatoId { get; set; }
        public string? NovoNome { get; set; }
        public string? NovoTelefone { get; set; }
        public string? NovoEmail { get; set; }

        public string? TipoOperacao { get; set; }

        public AtualizarContatoRequest(int contatoId, string novoNome, string novoTelefone, string novoEmail, string tipoOperacao)
        {
            ContatoId = contatoId;
            NovoNome = novoNome;
            NovoTelefone = novoTelefone;
            NovoEmail = novoEmail;
            TipoOperacao = tipoOperacao;
        }
    }
}
