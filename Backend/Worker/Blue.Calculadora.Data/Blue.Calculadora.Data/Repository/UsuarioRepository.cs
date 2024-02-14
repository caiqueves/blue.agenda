using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blue.Calculadora.Domain.Entity;  // Certifique-se de ter o namespace correto para a entidade Usuario
using Blue.Calculadora.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Blue.Calculadora.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Usuario>> GetAllUsuariosAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> GetUsuarioByIdAsync(int id)
        {
            if (_context != null)
            {
                return await _context.Usuarios.FindAsync(id);
            }

            // Se o contexto for nulo, considere lançar uma exceção personalizada ou retornar um resultado apropriado.
            return null;
        }

        public void AddUsuarioAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public void UpdateUsuarioAsync(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task DeleteUsuarioAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }
    }
}
