using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Parametro : IValidable, ICopiable<Parametro>
    {
        public string Clave {  get; set; }
        public string Valor { get; set; }

        public Parametro()
        {

        }

        public void Validar() 
        {
            if (string.IsNullOrEmpty(Clave)) throw new Exception("La clave no puede ser vacia");
            if (string.IsNullOrEmpty(Valor)) throw new Exception("El valor no puede ser vacia");
        }

        public void Copy(Parametro model)
        {
            Valor = model.Valor;
        }
    }
}
