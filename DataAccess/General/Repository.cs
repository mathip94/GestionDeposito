using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Exceptions;
using Domain.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace DataAccess
{
    public class Repository<T>: IRepository<T> where T : class, IIdentityById
    {
        protected DbContext Contexto { get; set; }

        public T Add(T item)
        {
            try
            {
                Contexto.Set<T>().Add(item);
                Contexto.SaveChanges();
                return item;
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
            
        }

        public void Remove(T item)
        {
            Contexto.Set<T>().Remove(item);
            Contexto.SaveChanges();
        }

        public void Update(T item)
        {
            Contexto.Entry(item).State = EntityState.Modified;
            Contexto.SaveChanges();
        }

        public virtual T Get(int id)
        {
            T item = Contexto.Set<T>().FirstOrDefault(e => e.Id == id);
            return item;
        }
    }
}
