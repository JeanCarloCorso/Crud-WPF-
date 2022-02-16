using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainAluno.Interfaces
{
    /// <summary>
    /// Interface para classes DAO
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IDAO<T>
    {
        bool Insert(T t);
        bool Update(T t);
        bool Delete(T t);
        List<T> Select();
    }
}
