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
        public DbSet<Contato>? Contatos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        // Adicione outras configurações de entidade, como chaves primárias, índices, relações, etc., no método OnModelCreating.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contato>()
    .HasKey(c => c.Id); // Configurando a chave primária

            modelBuilder.Entity<Contato>()
                .Property(c => c.Nome)
                .HasMaxLength(50); // Configurando a propriedade Nome para ter no máximo 50 caracteres

            modelBuilder.Entity<Contato>()
                .Property(c => c.Telefone)
                .HasMaxLength(50); // Configurando a propriedade Nome para ter no máximo 50 caracteres

            modelBuilder.Entity<Contato>()
              .Property(c => c.Email)
              .HasMaxLength(50); // Configurando a propriedade Nome para ter no máximo 50 caracteres



            // Configurações específicas para a entidade Usuario
            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.Id); // Configurando a chave primária

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Name)
                .IsRequired();

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Login)
                .IsRequired();

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Senha)
                .IsRequired();
        }

    }

}