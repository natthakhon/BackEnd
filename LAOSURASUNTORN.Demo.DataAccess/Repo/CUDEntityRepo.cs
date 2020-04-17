using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAOSURASUNTORN.Demo.Repository;

namespace LAOSURASUNTORN.Demo.DataAccess.Repo
{
    public class CUDEntityRepo<T> : ICUDEntityRepo<T>, IDisposable
        where T : class
    {
        private Context context;
        private IGetEntityRepo<T> getEntityRepo;

        public CUDEntityRepo(Context context, IGetEntityRepo<T> getEntityRepo)
        {
            this.context = context;
            this.getEntityRepo = getEntityRepo;
        }

        public CUDEntityRepo(Context context)
        {
            this.context = context;
        }

        public void Create(T entity)
        {   
            this.context.Set<T>().Add(entity);
        }

        public void Delete(int id)
        {
            if (this.getEntityRepo != null)
            {
                var item = this.getEntityRepo.GetItemById(id);
                this.context.Set<T>().Remove(item);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void Update(T entity)
        {
            this.context.Entry(entity).State = EntityState.Modified;
        }

        public async Task Save()
        {   
            await this.context.SaveChangesAsync();
        }

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
