using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class ResumenResponseDto
    {
        public IEnumerable<MovimientoDeStockResumenResponseDto> ResumenPorAño { get; set; }
    }
}
