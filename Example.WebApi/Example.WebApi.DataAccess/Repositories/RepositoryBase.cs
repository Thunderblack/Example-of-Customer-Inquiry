using Example.WebApi.DataAccess.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example.WebApi.DataAccess.Repositories
{
    public class RepositoryBase : IRepository
    {
        protected ApplicationDbContext _context;

        public RepositoryBase(ApplicationDbContext context)
        {
            this._context = context;
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this._context.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion IDisposable Support
    }
}
