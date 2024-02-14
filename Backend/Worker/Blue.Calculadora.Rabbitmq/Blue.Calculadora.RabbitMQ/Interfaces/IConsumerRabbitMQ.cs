using Blue.Calculadora.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue.Calculadora.RabbitMQ.Interfaces
{
    public interface IConsumerRabbitMQ
    {
        Task Consume();
    }
}
