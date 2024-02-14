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

        public IEnumerable<Contato> GetAllContatosAsync()
        {
            return _context.Contatos.ToListAsync().Result;
        }

        public Contato GetContatoByIdAsync(int id)
        {
            if (_context != null)
            {
                return _context.Contatos.FirstOrDefault( c => c.Id == id);
            }

            // Se o contexto for nulo, considere lançar uma exceção personalizada ou retornar um resultado apropriado.
            return null;
        }

        public void AddContatoAsync(Contato contato)
        {
            try
            {
                _context.Contatos.Add(contato);
                _context.SaveChanges();
            } 
            catch (DbUpdateException ex)
            {
                throw new Exception($"teste {ex.Message}");
            }
        }

        public void UpdateContatoAsync(Contato contato)
        {
            _context.Entry(contato).State = EntityState.Modified;
            
            _context.SaveChanges();
        }

        public void DeleteContatoAsync(int id)
        {
            var contato = _context.Contatos.FirstOrDefault(b => b.Id == id) ;

            if (contato != null)
            {
                _context.Contatos.Remove(contato);
                _context.SaveChanges();
            }
            else
            {
                // Se o contato não for encontrado, considere lançar uma exceção personalizada ou retornar um resultado apropriado.
                throw new Exception("Não foi possível deletar o contato, pois não foi encontrado.");
            }
        }
    }
}