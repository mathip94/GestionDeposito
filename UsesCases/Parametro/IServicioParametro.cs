using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsesCases;
    public interface IServicioParametro
    {
        void Add(ParametroDto dto);
        ParametroDto Get(string clave);
        void Remove(string clave);
        void Update(string clave, ParametroDto dto);
        IEnumerable<ParametroDto> GetManyByKey(string clave);
    }

