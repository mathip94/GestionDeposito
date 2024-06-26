using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsesCases
{
    public interface IServicioCRUD<Dto>
    {
        Dto Add(Dto dto);
        
        Dto Get(int id);
       
        void Remove(int id);

        void Update(int id, Dto dto);
    }
}
