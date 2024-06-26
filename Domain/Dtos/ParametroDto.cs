using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class ParametroDto : IValidable
    {
        public string Clave {  get; set; }
        public string Valor { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Clave)) throw new Exception("La clave no puede ser vacia");
            if (string.IsNullOrEmpty(Valor)) throw new Exception("El valor no puede ser vacia");
        }
    }
}
