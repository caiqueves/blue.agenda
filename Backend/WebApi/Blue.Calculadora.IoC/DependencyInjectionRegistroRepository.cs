using Blue.Calculadora.Domain.Repositories;
using Blue.Calculadora.Infra.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue.Calculadora.IoC
{
    public static class DependencyInjectionRegistroRepository
    {
        public static IServiceCollection AddRegistroRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IContatoRepository, ContatoRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();

            return services;
        }
    }
}


