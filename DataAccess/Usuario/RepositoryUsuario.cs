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
    public class RepositoryUsuario : Repository<Usuario>, IRepositoryUsuario<Usuario>
    {
        public RepositoryUsuario(DbContext dbContext)
        {
            Contexto = dbContext;
        }

        public IEnumerable<Usuario> GetByName(string nombre)
        {
            IEnumerable<Usuario> usuarios = Contexto.Set<Usuario>()
                                        .Where(usuario => usuario.Nombre.Contains(nombre));
            return usuarios;
        }

        public IEnumerable<Usuario> GetAll()
        {
            IEnumerable<Usuario> publicaciones = Contexto.Set<Usuario>();                            
            return publicaciones;
        }

        public Usuario GetByMail(string email)
        {
            Usuario usuario = Contexto.Set<Usuario>().FirstOrDefault(u => u.Email == email);
            return usuario;
        }

        public void Remove(Usuario usuario)
        {
            Contexto.Set<Usuario>().Remove(usuario);
            Contexto.SaveChanges();
        }
        
        public Usuario Add(Usuario usuario)
        {
            Contexto.Set<Usuario>().Add(usuario);
            Contexto.SaveChanges();
            return usuario;
        }

        public void Update(Usuario usuario)
        {
            Contexto.Entry(usuario).State = EntityState.Modified;
            Contexto.SaveChanges();
        }
    }
}
