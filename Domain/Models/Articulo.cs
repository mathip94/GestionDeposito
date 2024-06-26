using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Models
{
    public class Articulo : IValidable, IIdentityById, ICopiable<Articulo>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public double PrecioVenta {  get; set; }
        public int Stock {  get; set; }

        public void Copy(Articulo model)
        {
            Nombre = model.Nombre;
            Descripcion = model.Descripcion;
            Codigo = model.Codigo;
            PrecioVenta = model.PrecioVenta;
            Stock = model.Stock;
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Codigo))
            {
                throw new Exception("El código del artículo no puede estar vacío.");  
            }

            if (Codigo.Length != 13)
            {
                throw new Exception("El código del artículo debe tener 13 dígitos.");
            }

            if (Nombre.Length < 10 || Nombre.Length > 200)
            {
                throw new Exception("El nombre del artículo debe tener entre 10 y 200 caracteres.");
            }

            if (Descripcion.Length < 5)
            {
                throw new Exception("La descripcion debe tener al menos 5 caracteres");
            }

        }
    }
}
