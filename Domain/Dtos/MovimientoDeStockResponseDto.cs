using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class MovimientoDeStockResponseDto
    {
        public int Count { get; set; }

        public IEnumerable<MovimientoDeStock> Movimientos { get; set; }
    }
}
