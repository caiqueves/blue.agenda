using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

public static class FluentValidationExtensions
{
    public static IServiceCollection AddFluentValidation(this IServiceCollection services, Assembly assembly)
    {
        // Obtém todos os tipos no assembly que implementam IValidator<T>
        var validatorTypes = assembly.GetTypes()
            .Where(type => type.GetInterfaces().Any(inter => inter.IsGenericType && inter.GetGenericTypeDefinition() == typeof(IValidator<>)));

        // Registra cada validador no contêiner
        foreach (var validatorType in validatorTypes)
        {
            // Obtém o tipo genérico da interface IValidator<T>
            var interfaceType = validatorType.GetInterfaces().First(inter => inter.IsGenericType && inter.GetGenericTypeDefinition() == typeof(IValidator<>));

            // Obtém o tipo genérico do argumento da interface (por exemplo, AdicionarContatoRequest para IValidator<AdicionarContatoRequest>)
            var requestType = interfaceType.GetGenericArguments().First();

            // Registra o validador no contêiner
            services.AddTransient(interfaceType, validatorType);
        }

        return services;
    }
}