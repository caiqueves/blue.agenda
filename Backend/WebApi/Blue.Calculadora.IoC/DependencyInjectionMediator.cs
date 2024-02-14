using Blue.Calculadora.Domain.Handlers;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue.Calculadora.IoC
{

    public static class DependencyInjectionMediator
    {
        public static IServiceCollection AddMediatorHandler(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(AdicionarContatoHandler).Assembly);
            services.AddMediatR(typeof(BuscarCadastroPorIdHandler).Assembly);
            services.AddMediatR(typeof(AtualizarCadastroHandler).Assembly);
            services.AddMediatR(typeof(RemoverContatoHandler).Assembly);
            services.AddMediatR(typeof(BuscarCadastrosHandler).Assembly);

            services.AddMediatR(typeof(AutenticacaoHandler).Assembly);
            services.AddMediatR(typeof(CriarCadastroHandler).Assembly);
            return services;
        }
    }
}


