using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class MovimientoDeStockDto : IValidable, IIdentityById
    {
        public int Id { get; set; }
        public DateTime FechaYHora { get; set; }
        public int ArticuloId { get; set; }
        public int TipoDeMovimientoId { get; set; }
        public string ? MailUsuario { get; set; }
        public int CantidadDeUnidadesMovidas { get; set; }
        public int ? UsuarioId { get; set; }

        public void Validar()
        {
            if (FechaYHora > DateTime.Now) throw new Exception("La fecha no puede ser mayor que el día actual");
            if (ArticuloId <= 0) throw new Exception("El ID del artículo no puede ser nulo o negativo");
            if (TipoDeMovimientoId <= 0) throw new Exception("El ID del tipo de movimiento no puede ser nulo o negativo");
            if (CantidadDeUnidadesMovidas <= 0) throw new Exception("La cantidad de unidades movidas debe ser mayor a cero");
        }
    }
}
