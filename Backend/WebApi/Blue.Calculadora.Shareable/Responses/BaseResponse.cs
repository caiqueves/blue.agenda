using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue.Calculadora.Shareable.Responses
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public BaseResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public static BaseResponse SuccessResponse(string message = "Operação concluída com sucesso.")
        {
            return new BaseResponse(true, message);
        }

        public static BaseResponse ErrorResponse(string message = "Erro ao processar a operação.")
        {
            return new BaseResponse(false, message);
        }
    }
}
