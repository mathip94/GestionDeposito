using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IRepositoryParametro
    {
        void Add(Parametro item);
        void Update(Parametro item);
        void Remove(Parametro item);
        Parametro Get(string clave);
        IEnumerable<Parametro> GetManyByKey(string clave);
    }
}
