using Blue.Calculadora.Infra.Data;
using Blue.Calculadora.RabbitMQ.Interfaces;
using Blue.Calculadora.RabbitMQ.Servicos;
using Blue.Calculadora.Shareable.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Blue.Calculadora.IoC
{

    public static class DependencyInjectionMySQL
    {

        public static IServiceCollection AddMySQL(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MySQLConfig>(configuration.GetSection("MySQLConfig"));
        
            var host = configuration["DBHOST"] ?? configuration.GetConnectionString("HostName");
            var port = configuration["DBPORT"] ?? configuration.GetConnectionString("Port"); ;
            var password = configuration["MYSQL_PASSWORD"] ?? configuration.GetConnectionString("Password");
            var userid = configuration["MYSQL_USER"] ?? configuration.GetConnectionString("UserName");
            var productsdb = configuration["MYSQL_DATABASE"] ?? configuration.GetConnectionString("Database");

            string mySqlConnStr = $"server={"localhost"}; userid={"admin"};pwd={"admin"};port={3306};database={"Calculadora"}";

            services.AddDbContextPool<AppDbContext>(options =>
              options.UseMySql(mySqlConnStr,
                  ServerVersion.AutoDetect(mySqlConnStr)));
            return services;
        }
    }
}