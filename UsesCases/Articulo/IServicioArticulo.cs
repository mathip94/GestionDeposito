using Domain.Dtos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsesCases
{
    public interface IServicioArticulo : IServicioCRUD<ArticuloDto>
    {
        ArticuloDto Add(ArticuloDto articuloDto);
        ArticuloResponseDto GetAll();
        ArticuloDto GetByName(string nombre);
        ArticuloDto GetByCodigo(string codigo);
    }
}
