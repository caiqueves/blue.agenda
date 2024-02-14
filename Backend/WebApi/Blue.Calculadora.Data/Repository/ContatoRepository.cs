using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blue.Calculadora.Domain.Entity;
using Blue.Calculadora.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Blue.Calculadora.Infra.Data.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly AppDbContext _context;

        public ContatoRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public List<Contato> GetAllContatosAsync()
        {
            var retorno = _context.Contatos?.ToList() ?? new List<Contato>();
            return retorno;
        }

        public Contato GetContatoByIdAsync(int id)
        {

            var retorno = _context.Contatos?.Find(id) ?? new Contato();

            return retorno; // ou lançar uma exceção, dependendo do comportamento desejado
        }

        public void AddContatoAsync(Contato contato)
        {
            _context.Contatos?.Add(contato);
            _context.SaveChanges();
            // Adicione um tratamento adequado caso o contexto seja nulo (lançar exceção, log, etc.)
        }

        public void UpdateContatoAsync(Contato contato)
        {
            _context.Entry(contato).State = EntityState.Modified;
            _context.SaveChanges();

            // Adicione um tratamento adequado caso o contexto seja nulo (lançar exceção, log, etc.)
        }

        public void DeleteContatoAsync(int id)
        {
            var contato = _context.Contatos?.Find(id);
            if (contato != null)
            {
                _context.Contatos?.Remove(contato);
                _context.SaveChanges();
            }

            // Adicione um tratamento adequado caso o contexto seja nulo (lançar exceção, log, etc.)
        }
    }
}
