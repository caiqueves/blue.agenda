using Blue.Calculadora.Shareable.Requests;
using FluentValidation;

public class RemoverContatoRequestValidator : AbstractValidator<RemoverContatoRequest>
{
    public RemoverContatoRequestValidator()
    {
        RuleFor(x => x.ContatoId).GreaterThan(0).WithMessage("O ID do Contato deve ser maior que zero.");
    }
}

