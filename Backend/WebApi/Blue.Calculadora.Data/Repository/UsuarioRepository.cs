using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blue.Calculadora.Domain.Entity;
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

        public Usuario GetUsuarioByIdAsync(int id)
        {
            return _context.Usuarios?.Find(id);
        }

        public void AddUsuarioAsync(Usuario usuario)
        {
             _context.Usuarios.Add(usuario);
             _context.SaveChanges();
        }

        public async Task UpdateUsuarioAsync(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
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

        public Usuario GetUsuarioByLoginSenha(string login, string password)
        {
            var result = _context.Usuarios.FirstOrDefault(c => c.Login.ToLower() == login.ToLower() && c.Senha == password);

            if(result == null)
            {
                throw new Exception("Cadastro não localizado");
            }
            return result;
        }
    }
}
