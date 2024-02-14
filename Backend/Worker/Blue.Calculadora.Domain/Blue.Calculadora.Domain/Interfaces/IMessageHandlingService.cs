using Blue.Calculadora.Shareable.Requests;
using Blue.Calculadora.Shareable.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue.Calculadora.Domain.Interfaces
{
    public interface IMessageHandlingService
    {
        void HandleMessage(string message);
    }
}
