using FluentValidation;
using MediatR;
using Blue.Calculadora.Shareable.Requests;

public class AuthenticationRequestValidator : AbstractValidator<AuthenticationRequest>
{
    public AuthenticationRequestValidator()
    {
        RuleFor(x => x.Username).NotEmpty().NotNull().WithMessage("O campo Username é obrigatório.");
        RuleFor(x => x.Password).NotEmpty().NotNull().WithMessage("O campo Password é obrigatório.");
    }
}