using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue.Calculadora.Shareable.Exceptions
{
    public class ErroCriarCadastroException : Exception
    {
        public ErroCriarCadastroException(string message) : base(message)
        {

        }
    }
}
