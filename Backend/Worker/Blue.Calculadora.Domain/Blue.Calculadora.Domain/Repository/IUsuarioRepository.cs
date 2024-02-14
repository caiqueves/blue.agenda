using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blue.Calculadora.Domain.Entity;

namespace Blue.Calculadora.Domain.Repositories
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAllUsuariosAsync();
        Task<Usuario> GetUsuarioByIdAsync(int id);
        void AddUsuarioAsync(Usuario usuario);
        void UpdateUsuarioAsync(Usuario usuario);
        Task DeleteUsuarioAsync(int id);
    }
}
