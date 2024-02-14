

namespace Blue.Calculadora.Shareable.Requests
{
    public class AdicionarContatoRequest 
    {
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }

        public string? TipoOperacao { get; set; }

        public AdicionarContatoRequest(string nome, string telefone, string email, string tipoOperacao)
        {
            Nome = nome;
            Telefone = telefone;
            Email = email;
            TipoOperacao = tipoOperacao;
        }
    }
}
