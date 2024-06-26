using Domain.Dtos;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class MovimientoDeStock : IValidable, IIdentityById, ICopiable<MovimientoDeStock>
    {
        public int Id { get; set; }
        public DateTime FechaYHora { get; set; }
        public Articulo Articulo { get; set; }
        public TipoDeMovimiento TipoDeMovimiento { get; set; }
        public Usuario Empleado { get; set; }
        public int CantidadDeUnidadesMovidas { get; set; }
        public int ArticuloId { get; set; }
        public int UsuarioId { get; set; }
        public int TipoDeMovimientoId { get; set; }

        public void Copy(MovimientoDeStock model)
        {
            throw new NotImplementedException();
        }

        public void Validar()
        {
            if (FechaYHora <= DateTime.Now) throw new Exception("La fecha no puede ser mayor que el dia actual");
            if (Articulo == null) throw new Exception("El articulo no puede ser nulo");
            if (Empleado == null) throw new Exception("El empleado no puede ser nulo");
            if (TipoDeMovimiento == null) throw new Exception("El tipo de movimiento no puede ser nulo");
        }
    }
}
