using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class TipoDeMovimiento : IValidable, IIdentityById, ICopiable<TipoDeMovimiento>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public TipoMovimiento TipoMovimiento { get; set; }

        public void Copy(TipoDeMovimiento model)
        {
            this.Nombre = model.Nombre;
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Nombre)) throw new Exception("Tiene que darle un nombre");
        }
    }
}
