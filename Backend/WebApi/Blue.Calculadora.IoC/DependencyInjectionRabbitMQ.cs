using Blue.Calculadora.RabbitMQ.Interfaces;
using Blue.Calculadora.RabbitMQ.Servicos;
using Blue.Calculadora.Shareable.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blue.Calculadora.IoC
{

    public static class DependencyInjectionRabbitMQ
    {

        public static IServiceCollection AddRabbitMQAndRefit(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RabbitMQConfig>(configuration.GetSection("RabbitMQConfig"));
            services.AddTransient<IConnectionRabbitMQ, ConnectionRabbitMQ>();

            return services;
        }
    }
}