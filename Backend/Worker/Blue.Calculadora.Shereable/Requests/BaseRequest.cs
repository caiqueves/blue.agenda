using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue.Calculadora.Shereable.Requests
{
    public class BaseRequest
    {
        public string? TipoOperacao { get; set; }
    }

    public class BaseResponse
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
    }
}
