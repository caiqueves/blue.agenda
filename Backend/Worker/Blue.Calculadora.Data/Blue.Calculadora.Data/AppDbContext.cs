using Blue.Calculadora.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Blue.Calculadora.Infra.Data
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
           
        }

        // Defina as DbSet para suas entidades
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        // Adicione outras configurações de entidade, como chaves primárias, índices, relações, etc., no método OnModelCreating.
    }

}