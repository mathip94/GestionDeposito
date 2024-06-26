using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RepositoryParametro : IRepositoryParametro
    {
        private DbContext _contexto;

        public RepositoryParametro(DbContext contexto)
        {
            _contexto = contexto;
        }

        public void Add(Parametro item)
        {
            _contexto.Set<Parametro>().Add(item);
            _contexto.SaveChanges();
        }

        public void Remove(Parametro item)
        {
            _contexto.Set<Parametro>().Remove(item);
            _contexto.SaveChanges();
        }

        public void Update(Parametro item)
        {
            _contexto.Entry(item).State = EntityState.Modified;
            _contexto.SaveChanges();
        }

        public virtual Parametro Get(string clave)
        {
            Parametro item = _contexto.Set<Parametro>().FirstOrDefault(e => e.Clave.CompareTo(clave) == 0);
            return item;
        }

        public IEnumerable<Parametro> GetManyByKey(string clave)
        {
            IEnumerable<Parametro> parametros = _contexto.Set<Parametro>().Where(p => p.Clave.Contains(clave));
            return parametros;
        }
    }
}
