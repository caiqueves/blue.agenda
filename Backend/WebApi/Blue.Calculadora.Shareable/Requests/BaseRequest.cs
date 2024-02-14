using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue.Calculadora.Shareable.Requests
{
    public class BaseRequest
    {
        public string TipoOperacao { get; set; }

        public BaseRequest()
        {
        }

        protected BaseRequest(string tipoOperacao)
        {
            TipoOperacao = tipoOperacao;
        }
    }
}
