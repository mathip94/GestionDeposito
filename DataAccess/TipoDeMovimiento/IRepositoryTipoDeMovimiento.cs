using Domain.Dtos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IRepositoryTipoDeMovimiento : IRepository<TipoDeMovimiento>
    {
        TipoDeMovimientoResponseDto GetAll();
        TipoDeMovimientoResponseDto GetByName(string name, int skip, int take);

        bool IsTipoUsed(int tipoId);
    }
}
