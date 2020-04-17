using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAOSURASUNTORN.Demo.Repository;

namespace LAOSURASUNTORN.Demo.DataAccess.Repo
{
    public abstract class GetEntityRepo<T> : IGetEntityRepo<T>, IDisposable
        where T : class
    {
        protected Context context;
        protected GetEntityRepo(Context context)
        {
            this.context = context;
        }

        public IQueryable<T> GetAll()
        {
            return this.context.Set<T>();
        }

        public abstract IQueryable<T> GetByName(string name);

        public abstract T GetItemById(int id);
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
