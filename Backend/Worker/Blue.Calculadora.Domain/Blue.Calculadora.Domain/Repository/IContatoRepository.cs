using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blue.Calculadora.Domain.Entity;

namespace Blue.Calculadora.Domain.Repositories
{
    public interface IContatoRepository
    {
        IEnumerable<Contato> GetAllContatosAsync();
        Contato GetContatoByIdAsync(int id);
        void AddContatoAsync(Contato contato);
        void UpdateContatoAsync(Contato contato);
        void DeleteContatoAsync(int id);
    }
}
