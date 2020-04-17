using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAOSURASUNTORN.Demo.Repository
{
    public interface IGetEntityRepo<T>
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetByName(string name);
        T GetItemById(int id);
    }
}
