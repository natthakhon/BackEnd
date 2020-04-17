using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAOSURASUNTORN.Demo.Repository
{
    public interface ICUDEntityRepo<T>
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
        Task Save();
    }
}
