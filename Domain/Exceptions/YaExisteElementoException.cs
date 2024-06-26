using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class YaExisteElementoException : Exception
    {
        public YaExisteElementoException(string message) : base(message) { }
    }
}
