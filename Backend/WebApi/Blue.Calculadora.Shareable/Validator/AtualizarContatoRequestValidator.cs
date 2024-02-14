using Blue.Calculadora.Shareable.Requests;
using FluentValidation;

public class AtualizarContatoRequestValidator : AbstractValidator<AtualizarContatoRequest>
{
    public AtualizarContatoRequestValidator()
    {
        RuleFor(x => x.ContatoId).GreaterThan(0).WithMessage("O ID do Contato deve ser maior que zero.");
        RuleFor(x => x.NovoNome).NotEmpty().WithMessage("O campo NovoNome não pode estar vazio.");
        RuleFor(x => x.NovoTelefone).NotEmpty().WithMessage("O campo NovoTelefone não pode estar vazio.");
        RuleFor(x => x.NovoEmail).NotEmpty().WithMessage("O campo NovoEmail não pode estar vazio.").EmailAddress().WithMessage("O campo NovoEmail deve ser um endereço de e-mail válido.");
    }
}

