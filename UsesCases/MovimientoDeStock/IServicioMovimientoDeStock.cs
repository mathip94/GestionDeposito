using Domain.Dtos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsesCases
{
    public interface IServicioMovimientoDeStock : IServicioCRUD<MovimientoDeStockDto>
    {
        IEnumerable<MovimientoDeStockDto> GetAll();
        MovimientoDeStockResponseDto GetMovimientosPorArticuloYTipo(int articuloId, int tipoDeMovimientoId, int skip, int take);
        ArticuloResponseDto GetArticuloConMovimientosEnRangoDeFechas(DateTime fechaInicio, DateTime fechaFin, int skip, int take);
        ResumenResponseDto GetResumenMovimientos();
        MovimientoDeStockDto Add(MovimientoDeStockDto dto);
    }
}
