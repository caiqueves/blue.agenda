using MediatR;

namespace Blue.Calculadora.Shareable.Responses
{
    public class ObterContatoResponse 
    {
        public int IdContato { get; set; }
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
    }
}
