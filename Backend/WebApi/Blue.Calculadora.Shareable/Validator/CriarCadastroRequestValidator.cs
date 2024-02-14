using Blue.Calculadora.Shareable.Requests;
using FluentValidation;


public class CriarCadastroRequestValidator : AbstractValidator<CriarCadastroRequest>
{
    public CriarCadastroRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("O campo Nome é obrigatório.");
        RuleFor(x => x.Login).NotEmpty().WithMessage("O campo Login é obrigatório.");
        RuleFor(x => x.Senha).NotEmpty().WithMessage("O campo Senha é obrigatório.");
    }
}


