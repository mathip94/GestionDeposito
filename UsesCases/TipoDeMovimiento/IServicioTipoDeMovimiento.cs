using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsesCases
{
    public interface IServicioTipoDeMovimiento : IServicioCRUD<TipoDeMovimientoDto>
    {
        TipoDeMovimientoResponseDto GetAll();
        TipoDeMovimientoResponseDto GetByName(string name, int skip, int take);
        void Remove(int id);
        void Update(int id, TipoDeMovimientoDto dto);
    }
}
