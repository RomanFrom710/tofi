using System;

namespace BLL.Services
{
    public class Service : IService
    {
        protected bool Disposed { get; private set; }


        protected Service()
        {
            Disposed = false;
        }

        ~Service()
        {
            Dispose(false);
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
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

        }

        protected virtual void DisposeUnManagedOverride()
        {

        }
    }
}