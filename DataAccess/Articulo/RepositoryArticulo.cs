using Domain.Dtos;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataAccess
{
    public class RepositoryArticulo : Repository<Articulo>, IRepositoryArticulo
    {
        /*Puede que haya que hacer el no lo tengo claro del todo hay que probar
        
        private DbContext _contexto;

        public RepositoryPedido(DbContext contexto)
        {
            _contexto = contexto;
        }*/

        public RepositoryArticulo(DbContext dbContext) 
        {
            Contexto = dbContext;
        }

        //public IEnumerable<Articulo> GetAll()
        //{
        //    IEnumerable<Articulo> articulos = Contexto.Set<Articulo>().OrderBy(a => a.Nombre);

        //    return articulos;
        //}

        public Articulo GetByName(string nombre)
        {
            Articulo articulo = Contexto.Set<Articulo>().FirstOrDefault(a => a.Nombre == nombre);
     
            return articulo;
        }

        public Articulo GetByCodigo(string codigo)
        {
            Articulo articulo = Contexto.Set<Articulo>().FirstOrDefault(a => a.Codigo == codigo);

            return articulo;
        }

        public ArticuloResponseDto GetAll()
        {
            IEnumerable<Articulo> articulos = Contexto.Set<Articulo>().OrderBy(a => a.Nombre);

            int count = Contexto.Set<Articulo>().OrderBy(a => a.Nombre).Count();

            ArticuloResponseDto articuloResponse = new ArticuloResponseDto()
            {
                Count = count,
                Articulos = articulos
            };

            return articuloResponse;
        }

    }
}
