using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class TipoDeMovimientoDto : IValidable, IIdentityById
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public TipoMovimiento TipoMovimiento { get; set; }


        public void Validar()
        {
            if (string.IsNullOrEmpty(Nombre)) throw new Exception("Tiene que darle un nombre");
        }
    }
}
