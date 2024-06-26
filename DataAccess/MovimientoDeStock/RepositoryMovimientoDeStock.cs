using Domain.Dtos;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RepositoryMovimientoDeStock : Repository<MovimientoDeStock>, IRepositoryMovimientoDeStock
    {
        public RepositoryMovimientoDeStock(DbContext dbContext)
        {
            Contexto = dbContext;
        }

        public IEnumerable<MovimientoDeStock> GetAll()
        {
            IEnumerable<MovimientoDeStock> movimientoDeStocks = Contexto.Set<MovimientoDeStock>();
            return movimientoDeStocks;
        }

        public ArticuloResponseDto GetArticuloConMovimientosEnRangoDeFechas(DateTime fechaInicio, DateTime fechaFin, int skip, int take)
        {
            IEnumerable<Articulo> articulos = Contexto.Set<MovimientoDeStock>()
                .Where(m => m.FechaYHora >= fechaInicio && m.FechaYHora <= fechaFin)
                .Select(m => m.Articulo)
                .Distinct()
                .Skip(skip)
                .Take(take);

            int count = Contexto.Set<MovimientoDeStock>()
                .Where(m => m.FechaYHora >= fechaInicio && m.FechaYHora <= fechaFin)
                .Select(m => m.Articulo)
                .Distinct()
                .Count();

            ArticuloResponseDto articuloResponse = new ArticuloResponseDto()
            {
                Count = count,
                Articulos = articulos
            };


            return articuloResponse;
        }

        public MovimientoDeStockResponseDto GetMovimientosPorArticuloYTipo(int articuloId, int tipoDeMovimientoId, int skip, int take)
        {
            IEnumerable<MovimientoDeStock> movimientos = Contexto.Set<MovimientoDeStock>()
                .Include(m => m.TipoDeMovimiento)
                .Include(a => a.Articulo)
                .Include(e => e.Empleado)
                .Where(m => m.ArticuloId == articuloId && m.TipoDeMovimientoId == tipoDeMovimientoId)
                .OrderByDescending(m => m.FechaYHora)
                .ThenBy(m => m.CantidadDeUnidadesMovidas)
                .Skip(skip)
                .Take(take);

            int count = Contexto.Set<MovimientoDeStock>()
                .Include(m => m.TipoDeMovimiento)
                .Include(a => a.Articulo)
                .Include(e => e.Empleado)
                .Where(m => m.ArticuloId == articuloId && m.TipoDeMovimientoId == tipoDeMovimientoId)
                .OrderByDescending(m => m.FechaYHora)
                .ThenBy(m => m.CantidadDeUnidadesMovidas)
                .Count();

            MovimientoDeStockResponseDto movimientoResponse = new MovimientoDeStockResponseDto()
            {
                Count = count,
                Movimientos = movimientos,
            };


            return movimientoResponse; 
        }

        public ResumenResponseDto GetResumenMovimientos()
        {
            var resumenPorAnio = Contexto.Set<MovimientoDeStock>()
            .GroupBy(m => m.FechaYHora.Year)
            .Select(g => new MovimientoDeStockResumenResponseDto
            {
                Año = g.Key,
                Detalles = g.GroupBy(m => m.TipoDeMovimiento.Nombre)
                            .Select(t => new DetalleMovimientoDto
                            {
                                TipoMovimiento = t.Key,
                                Cantidad = t.Sum(m => m.CantidadDeUnidadesMovidas)
                            }).ToList(),
                TotalAnual = g.Sum(m => m.CantidadDeUnidadesMovidas)
            });

            return new ResumenResponseDto
            {
                ResumenPorAño = resumenPorAnio
            };
        }
    }
}
