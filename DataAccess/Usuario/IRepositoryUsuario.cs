using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;



namespace DataAccess
{
    public interface IRepositoryUsuario<T> : IRepository<T>
    {
        IEnumerable<Usuario> GetByName(string name);

        IEnumerable<Usuario> GetAll();

        Usuario GetByMail(string email);

        public Usuario Add(Usuario usuario);

        void Update(Usuario usuario);

        void Remove(Usuario usuario);


    }
}
