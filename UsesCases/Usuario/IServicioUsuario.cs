using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsesCases
{
    
        public interface IServicioUsuario : IServicioCRUD<UsuarioDtoRead>
        {
            IEnumerable<UsuarioDtoRead> GetByName(string nombre);

            IEnumerable<UsuarioDtoSend> GetAll();

            UsuarioDtoRead GetByMail(string email);

            void Update(string email, UsuarioDtoRead usuarioDto);

            UsuarioDtoRead Add(UsuarioDtoRead usuarioDto);

            void Remove(string email);

            //UsuarioDtoSend Login(string email, string pass);

        }
    
}
