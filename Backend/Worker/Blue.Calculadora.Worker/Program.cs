using Blue.Calculadora.Domain.Interfaces;
using Blue.Calculadora.Domain.Repositories;
using Blue.Calculadora.Domain.Services;
using Blue.Calculadora.Infra.Data;
using Blue.Calculadora.Infra.Data.Repositories;
using Blue.Calculadora.RabbitMQ.Interfaces;
using Blue.Calculadora.RabbitMQ.Servicos;
using Blue.Calculadora.Shareable.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {

        var configuration = hostContext.Configuration;

        services.Configure<RabbitMQConfig>(configuration.GetSection("RabbitMQConfig"));
        services.Configure<MySQLConfig>(configuration.GetSection("MySQLConfig"));

        services.AddDbContext<AppDbContext>((serviceProvider, optionsBuilder) =>
        {
            var config = serviceProvider.GetRequiredService<IOptions<MySQLConfig>>().Value;
            config.HostName = "localhost";
            config.Port = 3306;
            config.UserName = "admin";
            config.Password = "admin";
            var connectionString = $"server={config.HostName}; port={config.Port}; database={"Calculadora"}; user={config.UserName}; password={config.Password};";

            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        });

        services.AddScoped<IConsumerRabbitMQ, ConsumerRabbitMQ>();
        services.AddScoped<IMessageHandlingService, MessageHandlingService>();
        services.AddScoped<IContatoRepository, ContatoRepository>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();

        services.AddAutoMapper(typeof(DomainProfile).Assembly);
        services.AddHostedService<CalculadoraWorker>();
    })
    .Build();

host.Run();

