using System;
using DAL.Contexts;

namespace DAL.Repositories
{
    public abstract class Repository : IRepository
    {
        protected readonly TofiContext Context;


        protected bool Disposed { get; private set; }


        protected Repository(TofiContext context)
        {
            Context = context;
            Disposed = false;
        }

        ~Repository()
        {
            Dispose(false);
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int Save()
        {
            return Context.SaveChanges();
        }


        protected void Dispose(bool disposing)
        {
            if (Disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects.
                DisposeManagedOverride();
            }

            // Free any unmanaged objects.
            DisposeUnManagedOverride();
            Disposed = true;
        }

        protected virtual void DisposeManagedOverride()
        {
            Context.Dispose();
        }

        protected virtual void DisposeUnManagedOverride()
        {

        }
    }
}