using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsesCases
{
    public interface IServicioLogin<I, O>
    {
        O Login(I dto);
    }
}
