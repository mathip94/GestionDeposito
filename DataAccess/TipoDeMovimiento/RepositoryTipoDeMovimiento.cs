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
    public class RepositoryTipoDeMovimiento : Repository<TipoDeMovimiento>, IRepositoryTipoDeMovimiento
    {
        public RepositoryTipoDeMovimiento(DbContext dbContext)
        {
            Contexto = dbContext;
        }

        public TipoDeMovimientoResponseDto GetAll()
        {
            IEnumerable<TipoDeMovimiento> tipoMovimientos = Contexto.Set<TipoDeMovimiento>().OrderBy(t => t.Nombre);

            int count = Contexto.Set<TipoDeMovimiento>().OrderBy(t => t.Nombre).Count();

            TipoDeMovimientoResponseDto tiposDeMovimientoResponse = new TipoDeMovimientoResponseDto()
            {
                Count = count,
                Tipos = tipoMovimientos
            };

            return tiposDeMovimientoResponse;
        }

        public TipoDeMovimientoResponseDto GetByName(string name, int skip, int take)
        {
            IEnumerable<TipoDeMovimiento> tipos = Contexto.Set<TipoDeMovimiento>()
                .Where(t => t.Nombre.Contains(name))
                .Skip(skip)
                .Take(take);

            int count = Contexto.Set<TipoDeMovimiento>()
                .Where(t => t.Nombre.Contains(name))
                .Count();

            TipoDeMovimientoResponseDto tipoResponse = new TipoDeMovimientoResponseDto()
            {
                Count = count,
                Tipos = tipos
            };

            return tipoResponse;

        }

        public bool IsTipoUsed(int tipoId)
        {
            return Contexto.Set<MovimientoDeStock>().Any(m => m.TipoDeMovimiento.Id == tipoId);
        }
    }
}
