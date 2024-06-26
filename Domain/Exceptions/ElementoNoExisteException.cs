using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class ElementoNoExisteException : Exception
    {
        public ElementoNoExisteException(string message) : base(message)
        {
        }
    }
}
