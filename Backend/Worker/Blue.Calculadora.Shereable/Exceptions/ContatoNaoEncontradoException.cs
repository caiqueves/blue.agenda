using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue.Calculadora.Shareable.Exceptions
{
    public class ContatoNaoEncontradoException : Exception
    {
        public ContatoNaoEncontradoException(string message) : base(message)
        {

        }
    }
}
