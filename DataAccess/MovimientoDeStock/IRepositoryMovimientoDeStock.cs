using Domain.Dtos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess 
{
    public interface IRepositoryMovimientoDeStock : IRepository<MovimientoDeStock>
    {
        IEnumerable<MovimientoDeStock> GetAll();
        MovimientoDeStockResponseDto GetMovimientosPorArticuloYTipo(int articuloId, int tipoDeMovimientoId, int skip, int take);
        ArticuloResponseDto GetArticuloConMovimientosEnRangoDeFechas(DateTime fechaInicio, DateTime fechaFin, int skip, int take);
        ResumenResponseDto GetResumenMovimientos();
    }
}
