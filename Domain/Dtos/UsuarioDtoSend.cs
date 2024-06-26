using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class UsuarioDtoSend : IValidable
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public bool EsEncargado { get; set; }

        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
