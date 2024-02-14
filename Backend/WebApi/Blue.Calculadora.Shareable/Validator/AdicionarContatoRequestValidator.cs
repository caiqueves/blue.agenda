using Blue.Calculadora.Shareable.Requests;
using FluentValidation;


public class AdicionarContatoRequestValidator : AbstractValidator<AdicionarContatoRequest>
{
    public AdicionarContatoRequestValidator()
    {
        RuleFor(x => x.Nome).NotEmpty().WithMessage("O campo Nome é obrigatório.");
        RuleFor(x => x.Telefone).NotEmpty().WithMessage("O campo Telefone é obrigatório.");
        RuleFor(x => x.Email).NotEmpty().WithMessage("O campo Email é obrigatório.").EmailAddress().WithMessage("O campo Email deve ser um endereço de e-mail válido.");

    }
}


