using MediatR;

namespace Blue.Calculadora.Shareable.Responses
{
    public class ObterContatosResponse 
    {
        public List<ObterContatoResponse>? Contatos { get; set; }
    }

}
