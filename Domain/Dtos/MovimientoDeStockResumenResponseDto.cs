using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class MovimientoDeStockResumenResponseDto
    {
        public int Año { get; set; }
        public IEnumerable<DetalleMovimientoDto> Detalles { get; set; }
        public int TotalAnual { get; set; }
    }
}
