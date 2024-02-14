using Blue.Calculadora.Shareable.Requests;
using Blue.Calculadora.Shareable.Responses;
using FluentValidation;

public class ObterContatoRequestValidator : AbstractValidator<ObterContatoRequest>
{
    public ObterContatoRequestValidator()
    {
        RuleFor(x => x.ContatoId).GreaterThan(0).WithMessage("O ID do Contato deve ser maior que zero.");
    }
}
