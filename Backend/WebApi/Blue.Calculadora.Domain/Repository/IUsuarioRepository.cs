using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blue.Calculadora.Domain.Entity;

namespace Blue.Calculadora.Domain.Repositories
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAllUsuariosAsync();
        void AddUsuarioAsync(Usuario usuario);
        Task UpdateUsuarioAsync(Usuario usuario);
        Task DeleteUsuarioAsync(int id);
        Usuario GetUsuarioByLoginSenha(string login, string password);
    }
}
