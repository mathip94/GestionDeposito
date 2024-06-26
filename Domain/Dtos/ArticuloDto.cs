using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Dtos
{
    public class ArticuloDto : IValidable, IIdentityById
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public double PrecioVenta { get; set; }
        public int Stock { get; set; }

        public void Validar()
        {
            
        }
    }
}
