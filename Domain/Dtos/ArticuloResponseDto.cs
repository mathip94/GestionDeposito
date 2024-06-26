using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class ArticuloResponseDto
    {
        public int Count { get; set; }

        public IEnumerable<Articulo> Articulos { get; set; }
    }
}
