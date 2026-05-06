using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Appi
{
    public interface ICrud<T>
    {
        void Create(T item);
        void Update(T item);
        void Delete(T item);
        Task<List<T>> Read();
       

    }
}
